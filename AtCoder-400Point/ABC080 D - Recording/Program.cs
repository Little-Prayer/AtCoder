using System;
using System.Linq;
using System.Collections.Generic;

namespace ABC080_D___Recording
{
    class Program
    {
        static void Main(string[] args)
        {
            var NC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var events = new List<Event>();
            for (int i = 0; i < NC[0]; i++)
            {
                var stc = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                events.Add(new Event(stc[0], stc[2], false));
                events.Add(new Event(stc[1], stc[2], true));
            }

            events = events.OrderBy(e => e.time).ThenBy(e => e.isEnd).ToList();
            var isRecording = new bool[NC[1] + 1];
            var requireRecorder = 0;
            var lastProgramStart = new int[NC[1] + 1];
            foreach (Event e in events)
            {
                if (e.isEnd)
                {
                    if (lastProgramStart[e.channel] != e.time) isRecording[e.channel] = false;
                }
                else
                {
                    isRecording[e.channel] = true;
                    requireRecorder = Math.Max(requireRecorder, isRecording.Count(r => r));
                    lastProgramStart[e.channel] = e.time;
                }
            }
            Console.WriteLine(requireRecorder);
        }
    }
    struct Event
    {
        public int time;
        public bool isEnd;
        public int channel;
        public Event(int _time, int _channel, bool _isEnd)
        {
            time = _time;
            channel = _channel;
            isEnd = _isEnd;
        }
    }
}
