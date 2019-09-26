using System;
namespace DotKakasi
{
    public class DotKakasiException : Exception
    {
        public DotKakasiException()
        {
        }

        public DotKakasiException(string message)
            : base(message)
        {
        }

        public DotKakasiException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class UnknownCharacterException : Exception
    {
        public UnknownCharacterException()
        {
        }

        public UnknownCharacterException(string message)
            : base(message)
        {
        }

        public UnknownCharacterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class UnsupportedRomanRulesException : Exception
    {
        public UnsupportedRomanRulesException()
        {
        }

        public UnsupportedRomanRulesException(string message)
            : base(message)
        {
        }

        public UnsupportedRomanRulesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class UnknownOptionsException : Exception
    {
        public UnknownOptionsException()
        {
        }

        public UnknownOptionsException(string message)
            : base(message)
        {
        }

        public UnknownOptionsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class InvalidModeValueException : Exception
    {
        public InvalidModeValueException()
        {
        }

        public InvalidModeValueException(string message)
            : base(message)
        {
        }

        public InvalidModeValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class InvalidFlagValueException : Exception
    {
        public InvalidFlagValueException()
        {
        }

        public InvalidFlagValueException(string message)
            : base(message)
        {
        }

        public InvalidFlagValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}