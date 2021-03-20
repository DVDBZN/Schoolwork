using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace InventoryTracker
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //Connect to database and create tables
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TierItem>().Wait();  //Possibly unnecessary
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<ChildItem>().Wait();
            _database.CreateTableAsync<Item>().Wait();
            //_database.CreateTableAsync<Tag>().Wait();
            //_database.CreateTableAsync<TagRelation>().Wait();
            //_database.CreateTableAsync<UserSettings>().Wait();
        }

        //Check that username exists for Login
        public Task<List<User>> CheckUsername(string username)
        {
            return _database.QueryAsync<User>("SELECT Username FROM User WHERE Username = ?", username);
        }

        //Get user by username
        public Task<List<User>> GetUserAsync(string username)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Username = ?", username);
        }

        //Polymorphism FTW!
        //Get all users
        public Task<List<User>> GetUserAsync()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }

        //Save user
        async public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
                return await _database.UpdateAsync(user);
            else if ((await _database.QueryAsync<int>("SELECT COUNT(*) FROM TierItem"))[0] == 0)
            {
                //Manually iterating IDs becuase AutoIncrement is unique per table, not global within database
                user.ID = 1;
                return await _database.InsertAsync(user);
            }
            else
            {
                //Could be changed to get highest value of the three
                //For some reason ends up with only even numbers, but whatever
                int count = await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM User");
                count += await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM ChildItem");
                count += await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM Item");
                user.ID = count + 1;
                return await _database.InsertAsync(user);
            }
        }

        //Save object
        async public Task<int> SaveObjectAsync(ChildItem child)
        {
            if (child.ID != 0)
                return await _database.UpdateAsync(child);
            else
            {
                int count = await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM User");
                count += await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM ChildItem");
                count += await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM Item");
                child.ID = count + 1;
                return await _database.InsertAsync(child);
            }
        }

        //Save object
        async public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0)
                return await _database.UpdateAsync(item);
            else
            {
                int count = await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM User");
                count += await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM ChildItem");
                count += await _database.ExecuteScalarAsync<int>("SELECT MAX(ID) FROM Item");
                item.ID = count + 1;
                return await _database.InsertAsync(item);
            }
        }

        //Get all children based on ParentID
        public Task<List<ChildItem>> GetChildItems(int parentID)
        {
            return _database.QueryAsync<ChildItem>("SELECT * FROM ChildItem WHERE ParentID = ?", parentID);
        }

        //Get Item children based on ParentID
        public Task<List<Item>> GetItemChildren(int parentID)
        {
            return _database.QueryAsync<Item>("SELECT * FROM Item WHERE ParentID = ?", parentID);
        }

        //Get parent of object based on ParentID
        public Task<List<ChildItem>> GetParent(int parentID)
        {
            return _database.QueryAsync<ChildItem>("SELECT * FROM ChildItem WHERE ID = ?", parentID);
        }

        //Get counts of children of an object
        async public Task<List<int>> GetCounts(List<int> ParentIDs, List<int> counts)
        {
            //If ParentIDs is empty, return counts
            //(i.e. no more children to find)
            if (ParentIDs.Count == 0)
                return counts;

            List<int> searchNext = new List<int> { };

            //For each ParentID
            foreach (int i in ParentIDs)
            {
                //Find child IDs
                var list = await GetChildItems(i);
                var itemList = await GetItemChildren(i);
                counts[0] += itemList.Count;
                counts[6] += itemList.Count;

                //For each found child
                foreach (ChildItem j in list)
                {
                    //Add to search its children
                    searchNext.Add(j.ID);

                    //Add to counts
                    counts[0]++;

                    switch(j.Type)
                    {
                        case "Profile":
                            counts[1]++;
                            break;
                        case "Building":
                            counts[2]++;
                            break;
                        case "Room":
                            counts[3]++;
                            break;
                        case "Unit":
                            counts[4]++;
                            break;
                        case "Box":
                            counts[5]++;
                            break;
                        default:
                            break;
                    }
                }
            }

            ParentIDs = searchNext;
            //Recursiveness to get all children, not just direct ones
            return counts = await GetCounts(ParentIDs, counts);
        }

        //Delete object
        async public Task<int> DeleteObject(TierItem tierItem)
        {
            var children = await GetChildItems(tierItem.ID);
            var itemChildren = await GetItemChildren(tierItem.ID);

            foreach (ChildItem child in children)
            {
                //Recursive call to delete child's children, etc.
                await DeleteObject(child);
            }

            //Treating Items differently becuase of separate table
            foreach (Item item in itemChildren)
            {
                await _database.DeleteAsync(item);
            }

            return await _database.DeleteAsync(tierItem);
        }

        //Query all ChildItems based on query
        public Task<List<ChildItem>> GlobalSearch(string query)
        {
            return _database.QueryAsync<ChildItem>(query);
        }

        //Query all Items based on query
        public Task<List<Item>> GlobalItemSearch(string query)
        {
            return _database.QueryAsync<Item>(query);
        }

        //Query all ChildItems and Items based on query
        async public Task<List<ChildItem>> LocalSearch(List<ChildItem> Parents, string QueryPartOne, string QueryPartTwo, List<ChildItem> results)
        {
            if (Parents.Count == 0)
                return results;

            List<ChildItem> searchNext = new List<ChildItem> { };

            foreach (ChildItem i in Parents)
            {
                searchNext.AddRange(await GetChildItems(i.ID));
                results.AddRange(await _database.QueryAsync<ChildItem>(QueryPartOne + i.ID + QueryPartTwo));
                //Replace part of query with another to search other table
                //Could also have passed list of parents instead
                results.AddRange(await _database.QueryAsync<Item>((QueryPartOne.Replace("SELECT * FROM ChildItem WHERE User", "SELECT * FROM Item WHERE User")) + i.ID + QueryPartTwo));
            }

            Parents = searchNext;
            //Recursive to search within all descendants
            return await LocalSearch(Parents, QueryPartOne, QueryPartTwo, results);
        }
    }
}