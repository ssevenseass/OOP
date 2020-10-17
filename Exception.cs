using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using static System.StringComparison;
using System.Data;

namespace OOP_1Lab
{
    class FileIsNotFoundException : ArgumentException
    {

        public FileIsNotFoundException(string message) : base(message)
        {
        }
    }


    class NotASection : ArgumentException
    {
        public string S { get; }

        public NotASection(string message, string section)
            : base("not a Section")
        {
            S = section;
        }

        public NotASection(string message) : base(message)
        {
        }
    }

    class NotAName : ArgumentException
    {
        public string N { get; }

        public NotAName(string message, string first)
            : base(message)
        {
            N = first;
        }

        public NotAName(string message) : base(message)
        {
        }
    }

    class WrongCommand : ArgumentException
    {
        public string C { get; }

        public WrongCommand(string message, string command)
            : base(message)
        {
            C = command;
        }

        public WrongCommand(string message) : base(message)
        {
        }
    }

    class NotAnIntegerNumber : ArgumentException
    {
        public string Sect { get; }
        public string Nam { get; }

        public NotAnIntegerNumber(string message, string section, string name)
            : base(message)
        {
            Sect = section;
            Nam = name;
        }

        public NotAnIntegerNumber(string message) : base(message)
        {
        }
    }

    class NotADoubleNumber : ArgumentException
    {
        public string Sect { get; }
        public string Nam { get; }

        public NotADoubleNumber(string message, string section, string name)
            : base(message)
        {
            Sect = section;
            Nam = name;
        }

        public NotADoubleNumber(string message) : base(message)
        {
        }
    }

}