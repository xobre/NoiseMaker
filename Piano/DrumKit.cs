using System;
using System.Timers;
using Sanford.Multimedia.Midi;

namespace Piano
{
    class DrumKit
    {
        public static void DrumKitNotes()
        {
            Console.Clear();
            Console.WriteLine("Play notes using the top two rows of letters on your keyboard");
            Console.WriteLine("Drum Kit");

// Set timer to a one second interval.
            FreePlaycl.timer = new Timer(1000);
            FreePlaycl.timer.Elapsed += OnTimerEvent;
// Have the timer fire repeated events (true is the default)
            FreePlaycl.timer.AutoReset = false;
// Timer is "ready" to run
            FreePlaycl.timer.Enabled = true;
            
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.KeyChar)
                {
                    case 'q': PlayMidiNote(36); break;
                    case 'a': PlayMidiNote(37); break;
                    case 'w': PlayMidiNote(38); break;
                    case 's': PlayMidiNote(39); break;
                    case 'e': PlayMidiNote(40); break;
                    case 'd': PlayMidiNote(41); break;
                    case 'r': PlayMidiNote(42); break;
                    case 'f': PlayMidiNote(43); break;
                    case 't': PlayMidiNote(45); break;
                    case 'g': PlayMidiNote(46); break;
                    case 'y': PlayMidiNote(49); break;
                    case 'h': PlayMidiNote(50); break;
                    case 'u': PlayMidiNote(51); break;
                    case 'j': PlayMidiNote(52); break;
                    case 'i': PlayMidiNote(53); break;
                    case 'k': PlayMidiNote(54); break;
                    case 'o': PlayMidiNote(55); break;
                    case 'l': PlayMidiNote(56); break;
                    case 'p': PlayMidiNote(72); break;
                    case 'x': TitlePage.Title(); break;
                } 
            }
        }
        private static void PlayMidiNote(int note)
        {
            FreePlaycl.builder.Command = ChannelCommand.NoteOn;
// Controls MIDI Channel 10 (AKA 9) is percussion
            FreePlaycl.builder.MidiChannel = 9;
            FreePlaycl.builder.Data1 = note;
// Controls velocity (loudness) 127 is the highest
            FreePlaycl.builder.Data2 = 127;
            FreePlaycl.builder.Build();
            FreePlaycl.outDevice.Send(FreePlaycl.builder.Result);
// Starts Timer
            FreePlaycl.timer.Start();
        }
        private static void OnTimerEvent(Object source, ElapsedEventArgs e)
        {
            FreePlaycl.builder.Command = ChannelCommand.NoteOff;
            FreePlaycl.builder.Data2 = 0;
            FreePlaycl.builder.Build();
            FreePlaycl.outDevice.Send(FreePlaycl.builder.Result);
        }
    }
}
