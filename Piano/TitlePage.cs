using System;

namespace Piano
{
    class TitlePage
    {
        public static void Title()
        {
            Console.Clear();
            Console.WriteLine("                       _  _  _  _       _                                                   ");
            Console.WriteLine("                      (_)(_)(_)(_)_    (_)                                                  ");
            Console.WriteLine("                      (_)        (_)    _      _  _  _       _  _  _  _       _  _  _       ");
            Console.WriteLine("                      (_) _  _  _(_)   (_)    (_)(_)(_) _   (_)(_)(_)(_)_  _ (_)(_)(_) _    ");
            Console.WriteLine("                      (_)(_)(_)(_)     (_)     _  _  _ (_)  (_)        (_)(_)         (_)   ");
            Console.WriteLine("                      (_)              (_)   _(_)(_)(_)(_)  (_)        (_)(_)         (_)   ");
            Console.WriteLine("                      (_)              (_)  (_)_  _  _ (_)_ (_)        (_)(_) _  _  _ (_)   ");
            Console.WriteLine("                      (_)              (_)    (_)(_)(_)  (_)(_)        (_)   (_)(_)(_)      ");
            Console.WriteLine("\n\n\n\n\n                                       Free Play or Listen to Sweet Music?\n");
            Console.Write("                                                   Type f || s : ");
// Lets user decide between freeplay or sweet music, will only except two options
            string userInput = Console.ReadLine();
            string lowerCase= userInput.ToLower();
            char [] charInput = lowerCase.ToCharArray();
            if (charInput[0] == 'f') FreePlaycl.FreePlay();
            if (charInput[0] == 's') Songs.WhichSong();
            else Console.Clear(); Title();
        }                                                                   
    }
}
