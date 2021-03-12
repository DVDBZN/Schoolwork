using System;
using System.Windows.Forms;

namespace ConsoleApplication42
{
    class Program
    {
        static string UserChoice(string prompt, string choiceA, string choiceB, string choiceC)
        {
            Console.Write(prompt);
            string choice = Console.ReadLine();
            while (choice != choiceA && choice != choiceB && choice != choiceC)
            {
                Console.WriteLine("\nInvalid Choice!");
                Console.Write(prompt);
                choice = Console.ReadLine();
            }
            return choice;
        }

        static void Main(string[] args)
        {
            Program.Beginning();
        }

        static void Beginning()
        {
            string beginning = "\nYou have lived in your hometown for your entire life.\nHowever, no matter how you try to achieve happiness and peace in your life,\nyou always have a feeling of emptiness.";
            beginning += "\nTo add to your torment, you feel like you have a heavy burden that you carry\naround with you. Everyday that burden grows heavier and heavier.\n";
            beginning += "\nOne day a friend of yours gives you a book to read.\nHe claims that the truths found in this book will fill your emptiness,\nhelp you find peace, and relieve you of your burden.";
            beginning += "\nYou accept the book, not believing that anything can lift your burden,\nbut still humoring your friend.\nYou start reading the book and eventually get caught up in its amazing stories.";
            beginning += "\nYou start questioning if the stories in this book might be true and\nwonder how they relate to your circumstance.";
            beginning += "\nFrom this book you learn that your hometown will be destroyed\nand that to escape you would have to leave the city by going\nthrough the city gate and to the king's city, the Celestial City.\n";

            Console.WriteLine(beginning);

            string prompt = "You decide that it is time to make your decision: stay in your hometown with\nyour family, friends, job, and pleasures or leave the city to escape\nthe alleged \"destruction\" and possibly relieve yourself of your burden.";
            prompt += "\n(\"stay\" or \"leave\")";

            string choice = UserChoice(prompt, "leave", "stay", "leave");

            if (choice == "stay")
                Program.Stay();
            if (choice == "leave")
                Program.Leave();
        }
        static void Stay()
        {
            string stay = "\nYou decided that it would be better to stay.";
            stay += "\nAfter all, you should not believe\neverything that you read.";
            stay += "\n\nYou live in the same state as before for a few years,\ncompletely forgetting about the book.";

            Console.WriteLine(stay);

            Program.Fire();
        }
        static void Leave()
        {
            string leave = "\nYou decide that it would be better to risk losing what little amount\nof comfort you have left, if only to relieve yourself of your dull life.\n";
            leave += "\nYou soon meet two other travelers from your hometown.\nOne soon leaves you, thinking that you are crazy to  undertake such a journey\nbecuase of an old book.";
            leave += "\nThe other keeps going, believing that what you say is true.\nYou keep walking but you and your companion fall into a swamp.";
            leave += "\nYou both struggle to survive.\nSeeing your companion get out, you are renewed with hope of surviving.\nBut, to your horror, your companion gets up and leaves you.";
            leave += "\nWith much struggling and effort, you eventually pull yourself\nout and continue on your way.\n\nWith such a close call, you wonder if it would have been better to stay home.";

            Console.WriteLine(leave);

            string prompt = "Do you play it safe and go home, or do you continue with your journey?";
            prompt += "\n(\"continue\" or \"return\")";

            string choice = UserChoice(prompt, "continue", "return", "continue");

            if (choice == "continue")
                Program.Continue();
            if (choice == "return")
                Program.Return();
        }
        static void Return()
        {
            string return1 = "\nYou decided that it would be better to go home.";
            return1 += "\nAfter all, you should not believe everything that you read.";
            return1 += "\n\nYou live in the same state as before for a few years,\ncompletely forgetting about the book.";

            Console.WriteLine(return1);

            Program.Fire();
        }
        static void Continue()
        {
            string keepGoing = "\nYou believe that the gate is near and that to turn back would be a waste\nof your time. You are also curious about what lies ahead.";
            keepGoing += "\nYou keep walking and arrive at the gate.\nThe gate keeper tells you the way to the next stop and gives you a small key.\nYou follow his directions and arrive at a the foot of a short hill.";
            keepGoing += "\nAt the top of the hill you see a crude wooden structure shaped like a letter\nof an ancient language that you once saw.";
            keepGoing += "\nYou climb the hill and remember what the book said about this place:\nthis was the place where the Son of the King gave himself so that travellers,\nlike yourself, can live in the King's city.";
            keepGoing += "\nHere you believe that the events that happened here are true.\nAs soon as you do this your burden is lifted and you feel overwhelmed\nwith peace and joy.\nIt seems that you have achieved what you set out to do.";
            keepGoing += "\nThe book said that you should not return to your old life,\nbut persevere and continue to the Celestial City.\nIt also warned that the road would only get more difficult.";

            Console.WriteLine(keepGoing);

            string prompt = "\nDo you continue or do you return home?";
            prompt += "\n(\"continue\" or \"return\")";

            string choice = UserChoice(prompt, "continue", "return", "continue");

            if (choice == "continue")
                Program.Fork();
            if (choice == "return")
                Program.GoHome();
        }
        static void GoHome()
        {
            string home = "\nYou decide that you got what you wanted, therefore,\nit would be best not to risk anything else and go home.";
            home += "\nYou return home to your family, friends, and coworkers.\nHowever, you can't feel at peace anymore and eventually\nfeel the burden slowly returning.";

            Console.WriteLine(home);

            Program.Fire();
        }
        static void Fork()
        {
            string fork = "\nYou continue with your journey.\nAlthough you feel weary and cautious, you still have peace and joy.\nYou continue walking and eventually reach a dangerous incline.";
            fork += "\nYou notice two bypasses that seem safer than the one in the middle.";
            fork += "\nThere are two other travelers already at the fork.\nYou ask them if they know which way will lead you to your destination.\nThey say that any one will do, but cannot decide which one is the safest.";
            fork += "\nYou don't know whether you should trust either one because of your previous\nmishap. Besides, you were told to follow the middle road and not leave the path.\nIn addition, you don't know if either of the side paths could return\nto the main road.";

            Console.WriteLine(fork);
            string prompt = "\nDo you trust one of these strangers and go to the right or left\nor do you not risk it and go up the middle?";
            prompt += "\n(\"right\", \"left\", or \"middle\")";

            string choice = UserChoice(prompt, "right", "left", "middle");

            if (choice == "right")
                Program.WrongWay();
            if (choice == "left")
                Program.WrongWay();
            if (choice == "middle")
                Program.Middle();
        }

        static void WrongWay()
        {
            string wrongWay = "\nYou decide that it would be safer to travel with a companion,\ndespite the risks involved.";
            wrongWay += "\nYou start on your chosen path.\nAfter about an hour of walking, you and your companion hear an awful noise,\none that sounded like the roar of a large creature.";
            wrongWay += "\nYou and your companion were never heard from again.";

            Console.WriteLine(wrongWay);

            Program.End();
        }
        static void Middle()
        {
            string climb = "\nYou decide that it would be safer to travel alone for now.";
            climb += "\nYou start up in the steep path to the top.\nSeveral times you lose your footing and almost fall,\nbut each time you are miraculously held up by some mysterious, invisible force.";
            climb += "\nAt the top of the hill you see a palace. You knock on the gate and are told by\nthe gatekeeper that this palace was built by the King himself for pilgrims\nlike yourself.";
            climb += "\nHere you stay for three days, at the end of which you are given\na suit of armor, a sword, and a shield and told to continue your journey.";
            climb += "\n\nAfter a short time, you come to a small clearing.\nJust as you come to the center of the clearing, you hear a loud flapping noise.";
            climb += "\nYou look up to see a large creature, like that of a beastly man with\nthe wings of a dragon.\nHe lands in front of you and proclaims in a horrible voice\n\"I am Apollyon, king of the World. Bow before me and worship me.\"";
            climb += "\nYou were warned of this creature. He would kill anybody that did not bow.\nSince you have the suit of armor and a sword, you might risk fighting him.";

            Console.WriteLine(climb);

            string prompt = "\nDo you fight the creature, or die trying, or do you do as he says.";
            prompt += "\n(\"fight\" or \"bow\")";

            string choice = UserChoice(prompt, "fight", "bow", "fight");

            if (choice == "fight")
                Program.Fight();
            if (choice == "bow")
                Program.Bow();
        }
        static void Fight()
        {
            string fight = "\nYou know that the right thing would be to fight him.\nYou pull your sword out and start attacking him.";
            fight += "\nYou have had no experience with any form of combat whatsoever,\nyet, you felt that same force that kept you from falling before now guiding\nyourevery movement.";
            fight += "\nYou keep fighting him with your sword and using your shield to block\nhis fiery darts. This goes on for half a day and you begin to grow wearier\nthan you thought possible.";

            Console.WriteLine(fight);

            Program.Random();
        }
        static void Win()
        {
            string win = "\nJust when you thought that you will lose consciousness,\nyou see that Apollyon wavers on his attack.\nYou take advantage of this and take a quick sidestep and thrust your sword\ninto his side as he flies by.";
            win += "\nApollyon shrieks out and flies up and away. You have defeated Apollyon.";


            Console.WriteLine(win);

            string prompt = "\nYou are faced with another choice:\ncontinue, go back home, go back to the palace that was used as a rest stop.";
            prompt += "\n(\"go home\", \"palace\", or \"continue\")";

            string choice = UserChoice(prompt, "go home", "palace", "continue");

            if (choice == "go home")
                Program.GoHome();
            if (choice == "palace")
                Program.Palace();
            if (choice == "continue")
                Program.Path();
        }
        static void Palace()
        {
            string palace = "\nYou decide that you have gone too far to return home. You go back to the palace.";
            palace += "\nWhen you arrive you are told that you cannot stay.\nEither continue to the Celestial City or go home.";

            Console.WriteLine(palace);

            string prompt = "\n(\"go home\" or \"continue\")";

            string choice = UserChoice(prompt, "go home", "continue", "continue");

            if (choice == "go home")
                Program.GoHome();
            if (choice == "continue")
                Program.Path();
        }
        static void Path()
        {
            string path = "\nYou continue on the path and arrive at a point where the road takes\na sharp turn to the right.\nYou can see across a large meadow that the road just goes around it.";
            path += "\nYou could save yourself some time and energy if you just jump the fence\nand cut across this meadow.";

            Console.WriteLine(path);

            string prompt = "\nDo you want to cut across the meadow or follow the road?";
            prompt += "\n(\"meadow\" or \"road\")";

            string choice = UserChoice(prompt, "meadow", "road", "road");

            if (choice == "meadow")
                Program.DoubtingCastle();
            if (choice == "road")
                Program.EnchantedGround();
        }
        static void DoubtingCastle()
        {
            string doubtingCastle = "\nYou want to get to the Celestial City as quickly as possible.\nYou see a \"No Tresspassing\" sign but ignore it.";
            doubtingCastle += "\nYou were walking across the meadow for about an hour when you notice that\nsuddenly the sky grew dark and the wind started to blow harder.";
            doubtingCastle += "\nIt starts raining so hard that the meadow starts to get flooded.\nYou run for higher ground and find some shelter.\nYou can at least get some rest while the storm settles down.";
            doubtingCastle += "\nBefore long, you fall asleep.";
            doubtingCastle += "\n\nYou awake to the sound of a low thudding noise.\nYou remember the events of the previous night and continue on your journey.";
            doubtingCastle += "\nJust as you are about to leave the meadow, you turn your head to see the source\nof the thudding that has steadily grown louder: a giant.";
            doubtingCastle += "\nYou try to run away, but the giant was already too close.\nHe captures you and takes you to his castle.\nHis castle was not at all a pleasant place to be.\nThe entire area was engulfed in darkness cast by the large trees.";
            doubtingCastle += "\nInside the castle was even darker. It smelled of death and pain.\nYou could hear the cries of pain of the giants prisoners.";
            doubtingCastle += "\nThe giant takes you to your cell where you see a body chained to the wall.\nYou are also chained to the wall and locked in the cell.";
            doubtingCastle += "\nWhen the giant leaves you hear a voice come from the body.\nIt turns out that he is also a traveler to the Celestial City.\nHe was captured the same way you were and has been imprisoned there\nfor three months.";
            doubtingCastle += "\nYou and your new friend talk about the book that both of you had been reading,\nyour troubles on the way to the Celestial City, and your hopes of escaping.";
            doubtingCastle += "\nAbout a month later, the giant enters the cell with a bottle.\nHe says that you have the option to drink the poison to end your torment,\nor you can continue living as you are and the giant will find a much more\npainfull death for you.";
            doubtingCastle += "\nThinking that you were too weak to make any attempt of escape,\nhe unchains both of you so that you can drink the poison.";

            Console.WriteLine(doubtingCastle);

            string prompt = "\nDo you drink the poison or not?";
            prompt += "\n(\"drink\" or \"not\")";

            string choice = UserChoice(prompt, "drink", "not", "not");

            if (choice == "drink")
                Program.Poison();
            if (choice == "not")
                Program.Escape();
        }
        static void Poison()
        {
            string poison = "\nYou decide to drink the poison.\nYou have gone through enough torment on this journey. It is time to end it.";
            poison += "\nYou awake in a dungeon. You feel pain all over your body.\nYou realize that you had been taken to Apollyon's dungeon, where he eternally\ntorments travellers to the Celestial City that left the correct path.";
            poison += "\nYou had betrayed the King and now you are reaping the consequences.\nHere you will spend eternity, alone.";

            Console.WriteLine(poison);

            Program.End();
        }
        static void Escape()
        {
            string escape = "\nYou decide that if you drink the poison,\nyou will never get to see the Celestial City.\nYou pour the contents down the drain and continue to talk with your friend.";
            escape += "\nSuddenly, you remember the key that was given to you.\nYou had been wearing it around your neck the entire time.\nEven though it is much too small for the lock on the door, you try it anyway.";
            escape += "\nTo your surprise, the key unlocks the door and, with your friends help,\nyou push the door open.";
            escape += "\nOn your way out you unlock other doors to let other prisoners escape,\nsome of which were too weak to even stand.";
            escape += "\nEveryone runs out of the castle into the forest,\nand then out of the forest and back onto the road.";
            escape += "\nFor now, most of the group stays together to share stories.";
            escape += "\nAs you continue, the group begins thinning out.\nSome lagging behind due to weakness,\nothers running ahead for joy of being freed.";
            escape += "\nEventually, just your new companion has stayed with you.\nSoon, your friend grows tired and slows down.\nHe tells you to go ahead and that you shall meet him in the Celestial City.";

            Console.WriteLine(escape);

            Program.EnchantedGround();
        }
        static void EnchantedGround()
        {
            string enchantedGround = "\nYou continue walking and soon come to a point where the road ends.\nRight in front of you is a field. You have been warned about it.";
            enchantedGround += "\nThe only way is to go through it, but you need to be careful.\nOf what, you were no told.";
            enchantedGround += "\nAs you continue, you slowly fall asleep.\nSeveral times you catch yourself dozing off.";

            Console.WriteLine(enchantedGround);

            string prompt = "\nShould you just take a short nap and continue when you have more energy or\nshould you resist and continue through the field.";
            prompt += "\n(\"sleep\" or \"continue\")";

            string choice = UserChoice(prompt, "sleep", "continue", "continue");

            if (choice == "sleep")
                Program.Sleep();
            if (choice == "continue")
                Program.Final();
        }
        static void Sleep()
        {
            string sleep = "\nYou cannot resist any longer. You collapse and immediately slip into dreams.\nBut you never\nwake\nup.";

            Console.WriteLine(sleep);

            Program.End();
        }
        static void Final()
        {
            string final = "\nYou resist the sleepiness and continue stumbling along.\nJust as you feel that you can't go any longer you feel a surge of energy.\nThis surge gave you the strength to continue until you left the field.";
            final += "\nYou soon arrive at a raging river. Just beyond the river you see the gateway to\nthe Celestial City.\nFinally, after all that you have been through, you have only one obstacle left:\nthe river.";
            final += "\nThe only way across is to swim. You throw your armor and sword into the river.\nYou will not be needing them after you cross the river. You quickly run in and\nstart your swim across. About halfway across the river\nyou feel yourself being\npulled underneath the surface.";
            final += "\nInstead of panicking, like you would have before this journey, \nyou feel completely at peace, as if even if you do drown,\nyou will somehow still arrive at the Celestial City.";
            final += "\nYou make a final attempt, using all of your remaining energy.\nBefore you knew what had happened, you climb out of the water and collapse\nonto the shore, relieved that your final trial has ended.";
            final += "\nYou get up and walk to the gates, where you are given a clean, white set of\nclothes. You walk into the city with a new burst of seemingly unending energy.";
            final += "\nHere you live for the rest of time, with no illness, death, pain, or sadness.\nYears later, even your family and a few friends arrived one way or another.";

            Console.WriteLine(final);

            Program.End();
        }
        static void Lose()
        {
            string lose = "\nJust when you thought that you will lose consciousness,\nyou see that Apollyon wavers on his attack.\nYou try to take advantage of this but collapse of exhaustion.";
            lose += "\nYou wake up to see yourself clothed in white and\nstanding in the middle of a majestic golden city.\nYou immediatly recognized it as the Celestial City,\nthe destination of your journey.";
            lose += "\nYou had not lost to Apollyon, you had just found another\npath to your destination.\nHere you live in peace, without illness, death, pain, or sadness\nfor as long as time continued, and then beyond that.";

            Console.WriteLine(lose);

            Program.End();
        }
        static void Bow()
        {
            string bow = "\nYou decide that you want to keep your life.\nAs you bow you hear Apollyons wings beat the wind. Before you can look up,\nhe is upon you.";
            bow += "\nYou awake in a dungeon. You feel pain all over your body.\nYou realize that you had been taken to Apollyon's dungeon,\nwhere he eternally torments travellers to the Celestial City\nthat left the correct path.";
            bow += "\nYou had betrayed the King and now you are reaping the consequences.\nHere you will spend eternity, alone.";

            Console.WriteLine(bow);

            Program.End();
        }
        static void Fire()
        {
            string fire = "\n\nOne day, as you are doing your daily routine,\nyou hear a sound like a loud explosion.\nYou run to the nearest window to see where the noise came from.";
            fire += "\nYou see a blinding flash and are knocked to the floor.";
            fire += "\nThe city was destroyed. By what, or whom, you do not know.\nYou, and everyone in the city at the time, died.";

            Console.WriteLine(fire);

            Program.End();
        }
        static void Random()
        {
            Random randomGenerator = new Random();
            int roll = randomGenerator.Next(1, 3);

            if (roll == 1)
            {
                Program.Win();
            }

            if (roll == 2)
            {
                Program.Lose();
            }
        }
        static void End()
        {
            string end = "\n\nYou have come to the end of your journey,\neither by reaching a \"dead end\" off of the main road\nor by reaching the Celestial City.";
            end += "\nThank you for your participation in this program.\nThe storyline is loosely based off of John Bunyan's book\n\"The Pilgrim's Progress\" which is public domain in the USA.";
            end += "\n\nCredits:\n\nExecutive Producer\nDavid Bozin\n\nProject Manager\nDavid Bozin\n\nLead Programmer\nDavid Bozin\n\nGraphics Developers\nThe Microsoft Team\n\nSound and Music\nNobody\n\nSpecial Thanks to\nBeta Testers\n";
            Console.ReadLine();
            Console.WriteLine(end);
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("John Bozin ");
            Console.ResetColor();
            Console.Write("and The Tishbyte\n\nAnd funded by\nmy parents\n\n");

            Console.WriteLine("\nPress \"enter\" to end the adventure.");

            Console.ReadLine();

            DialogResult result = MessageBox.Show("Do you want to retry?", "Try Again?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Program.Beginning();
        }
    }
}