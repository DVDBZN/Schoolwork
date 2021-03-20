using System;
using SQLite;

namespace InventoryTracker
{
    //Base Class for inheritance
    public class TierItem
    {
        [PrimaryKey, NotNull]
        public int ID { get; set; }
        public string User { get; set; }

        //Types: User, Profile, Building, Room, Unit, Box, Item
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastChangedOn { get; set; }
    }

    //Derived classes User, ChildItem, and Item
    public class User : TierItem
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
    }

    public class ChildItem : TierItem
    {
        public int ParentID { get; set; }
        public string Name { get; set; }
    }

    public class Item : ChildItem
    {
        public bool InUse { get; set; }
        public DateTime InUseNotify { get; set; }
        public string InUseMessage { get; set; }
        public DateTime ExpirationNotify { get; set; }
    }

    //TAGS future feature
    //Either make a separate class for color tags, or a tag is turned into a color tag by having a name that is a color (e.g. "black" = #0000, etc.)
    /*
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class TagRelation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int TagID { get; set; }
    }

    public class UserSettings
    {
        public int UserID { get; set; }
        public int Theme { get; set; }
    }
    */
}