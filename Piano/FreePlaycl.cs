using System;
using System.Threading;
using Sanford.Multimedia.Midi;
using System.Timers;


namespace Piano
{
    class FreePlaycl
    {
// Create a timer
        public static System.Timers.Timer timer;
// Provides functionality for building ChannelMessages
        public static ChannelMessageBuilder builder = new ChannelMessageBuilder();
// Provides basic functionality for sending MIDI messages
        public static OutputDevice outDevice = new OutputDevice(0);

        public static void FreePlay()
        {
            Console.Clear();
            Console.WriteLine("                             _  _  _  _                                          ");
            Console.WriteLine("                            (_)(_)(_)(_)                                       ");
            Console.WriteLine("                            (_)        _            _  _  _  _      _  _  _  _       ");
            Console.WriteLine("                            (_) _  _  (_)  _(_)(_) (_)(_)(_)(_)_   (_)(_)(_)(_)_    ");
            Console.WriteLine("                            (_)(_)(_)  (_)(_)     (_) _  _  _ (_) (_) _  _  _ (_)   ");
            Console.WriteLine("                            (_)        (_)        (_)(_)(_)(_)(_) (_)(_)(_)(_)(_)   ");
            Console.WriteLine("                            (_)        (_)        (_)_  _  _  _   (_)_  _  _  _     ");
            Console.WriteLine("                            (_)        (_)          (_)(_)(_)(_)    (_)(_)(_)(_)    ");
            Console.WriteLine("  \n   ");
            Console.WriteLine("                         _  _  _  _    _  _                                            _      ");
            Console.WriteLine("                        (_)(_)(_)(_)_ (_)(_)                                          (_)     ");
            Console.WriteLine("                        (_)        (_)   (_)      _  _  _     _               _       (_)      ");
            Console.WriteLine("                        (_) _  _  _(_)   (_)     (_)(_)(_) _ (_)_           _(_)      (_)      ");
            Console.WriteLine("                        (_)(_)(_)(_)     (_)      _  _  _ (_)  (_)_       _(_)        (_)    ");
            Console.WriteLine("                        (_)              (_)    _(_)(_)(_)(_)    (_)_   _(_)                   ");
            Console.WriteLine("                        (_)            _ (_) _ (_)_  _  _ (_)_     (_)_(_)             _      ");
            Console.WriteLine("                        (_)           (_)(_)(_)  (_)(_)(_)  (_)     _(_)              (_)     ");
            Console.WriteLine("                                                              _  _ (_)                       ");
            Console.WriteLine("                                                             (_)(_)                            \n");
            Console.WriteLine("                                     Beep Boop (b), Piano (p), Drum Kit (d)");
            Console.Write("                                   Type in 'x' to return to the Home Screen!  ");
//User has four options, will only except those options             
            string userInput = Console.ReadLine();
            string lowerCase = userInput.ToLower();
            char[] charInput = lowerCase.ToCharArray();
            if (charInput[0] == 'b') KeyDownBeep();
            if (charInput[0] == 'p') PlayPianoNotes();
            if (charInput[0] == 'd') DrumKit.DrumKitNotes();
            if (charInput[0] == 'x') TitlePage.Title();
            else Console.Clear(); FreePlay();
        }
        public static void PlayPianoNotes()
        {
            Console.Clear();
            Console.WriteLine("Play notes using the top two rows of letters on your keyboard");
            Console.WriteLine("Piano Notes");

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimerEvent;
            timer.AutoReset = false;
            timer.Enabled = true;

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.KeyChar)
                {
                    case 'q': PlayMidiNote(40); break;
                    case 'a': PlayMidiNote(43); break;
                    case 'w': PlayMidiNote(46); break;
                    case 's': PlayMidiNote(49); break;
                    case 'e': PlayMidiNote(52); break;
                    case 'd': PlayMidiNote(55); break;
                    case 'r': PlayMidiNote(58); break;
                    case 'f': PlayMidiNote(61); break;
                    case 'g': PlayMidiNote(64); break;
                    case 'y': PlayMidiNote(67); break;
                    case 'h': PlayMidiNote(70); break;
                    case 'u': PlayMidiNote(73); break;
                    case 'j': PlayMidiNote(76); break;
                    case 'i': PlayMidiNote(79); break;
                    case 'k': PlayMidiNote(82); break;
                    case 'o': PlayMidiNote(85); break;
                    case 'l': PlayMidiNote(88); break;
                    case 'p': PlayMidiNote(91); break;
                    case 'x': TitlePage.Title(); break;
                }
            }
        }
        private static void PlayMidiNote(int note)
        {
            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = note;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);
            timer.Start();
        }
        private static void OnTimerEvent(Object source, ElapsedEventArgs e)
        {
            builder.Command = ChannelCommand.NoteOff;
            builder.Data2 = 0;
            builder.Build();
            outDevice.Send(builder.Result);
        }
        static void KeyDownBeep()
        {
        Console.Clear();
        Console.WriteLine("Play notes using the top two rows of letters on your keyboard");
        Console.WriteLine("BeepBoops");
        
        ConsoleKey userInputBeep = Console.ReadKey().Key;
        switch (userInputBeep)
        {
            case (ConsoleKey.Q): Console.Beep(250, 50); break;
            case (ConsoleKey.A): Console.Beep(300, 50); break;
            case (ConsoleKey.W): Console.Beep(350, 50); break;
            case (ConsoleKey.S): Console.Beep(400, 50); break;
            case (ConsoleKey.E): Console.Beep(450, 50); break;
            case (ConsoleKey.D): Console.Beep(500, 50); break;
            case (ConsoleKey.R): Console.Beep(550, 50); break;
            case (ConsoleKey.F): Console.Beep(600, 50); break;
            case (ConsoleKey.T): Console.Beep(650, 50); break;
            case (ConsoleKey.G): Console.Beep(700, 50); break;
            case (ConsoleKey.Y): Console.Beep(750, 50); break;
            case (ConsoleKey.H): Console.Beep(800, 50); break;
            case (ConsoleKey.U): Console.Beep(850, 50); break;
            case (ConsoleKey.J): Console.Beep(875, 50); break;
            case (ConsoleKey.I): Console.Beep(900, 50); break;
            case (ConsoleKey.K): Console.Beep(925, 50); break;
            case (ConsoleKey.O): Console.Beep(950, 50); break;
            case (ConsoleKey.L): Console.Beep(975, 50); break;
            case (ConsoleKey.P): Console.Beep(1000, 50); break;
            case (ConsoleKey.X): TitlePage.Title(); break;
        }
            while (true)
            {
                KeyDownBeep();
                Thread.Sleep(50);
            }
        }
    }
}


