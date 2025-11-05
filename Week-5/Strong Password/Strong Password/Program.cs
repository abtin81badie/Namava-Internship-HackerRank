using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'MinimumNumber' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING password
     */
    private static readonly HashSet<char> DefaultAllowedSpecials =
        new HashSet<char>("!@#$%^&*()-+");

    private static bool IsValidChar(char c, ISet<char> allowedSpecials) =>
    char.IsLetterOrDigit(c) ||
    ((char.IsPunctuation(c) || char.IsSymbol(c)) && allowedSpecials.Contains(c));


    private static void CheckConstraints(int n, string password)
    {
        if (n > 100 || n < 1)
            throw new ArgumentException($"Parameter 'n' ({n}) is out of the valid range [1, 100].", nameof(n));

        if (password.Any(c => !IsValidChar(c, DefaultAllowedSpecials)))
            throw new ArgumentException("Password contains invalid characters.", nameof(password));
    }

    // Rules and Fluent Builder
    public sealed class PasswordRules
    {
        public bool RequireDigit { get; set; } = true;
        public bool RequireLower { get; set; } = true;
        public bool RequireUpper { get; set; } = true;
        public bool RequireSpecial { get; set; } = true;

        public int MinLength { get; set; } = 6;

        public ISet<char> AllowedSpecials { get; set; } = new HashSet<char>(DefaultAllowedSpecials);
    }

    public sealed class PasswordValidatorBuilder
    {
        private readonly PasswordRules _rules = new();
        public PasswordValidatorBuilder RequireDigit(bool on = true) { _rules.RequireDigit = on; return this; }
        public PasswordValidatorBuilder RequireLower(bool on = true) { _rules.RequireLower = on; return this; }
        public PasswordValidatorBuilder RequireUpper(bool on = true) { _rules.RequireUpper = on; return this; }
        public PasswordValidatorBuilder RequireSpecial(bool on = true) { _rules.RequireSpecial = on; return this; }

        public PasswordValidatorBuilder MinLength(int len) { _rules.MinLength = len; return this; }
        public PasswordValidatorBuilder AllowedSpecials(string specials)
        {
            _rules.AllowedSpecials = new HashSet<char>(specials ?? string.Empty);
            return this;
        }


        public PasswordValidator Build() => new PasswordValidator(_rules);

    }

    public sealed class PasswordValidator
    {
        private readonly PasswordRules _rules;
        public PasswordValidator(PasswordRules rules) => _rules = rules;

        public int ChangesNeeded(string password)
        {
            bool hasDigit = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool hasSpecial = false;

            foreach (var c in password)
            {
                if (char.IsDigit(c)) hasDigit = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsUpper(c)) hasUpper = true;
                else if ((char.IsPunctuation(c) || char.IsSymbol(c)) && _rules.AllowedSpecials.Contains(c))
                    hasSpecial = true;

                // Anything else would have been rejected by CheckConstraints.
            }

            int missingTypes = 0;
            if (_rules.RequireDigit && !hasDigit) missingTypes++;
            if (_rules.RequireLower && !hasLower) missingTypes++;
            if (_rules.RequireUpper && !hasUpper) missingTypes++;
            if (_rules.RequireSpecial && !hasSpecial) missingTypes++;

            int lengthDeficit = Math.Max(0, _rules.MinLength - password.Length);
            return Math.Max(missingTypes, lengthDeficit);
        }
    }

    public static int MinimumNumber(int n, string password)
    {
        CheckConstraints(n, password);

        var validator = new PasswordValidatorBuilder()
            .RequireDigit(true)
            .RequireLower(true)
            .RequireUpper(true)
            .RequireSpecial(true)
            .MinLength(6)
            .AllowedSpecials("!@#$%^&*()-+")
            .Build();

        return validator.ChangesNeeded(password);
    }

    //public class PasswordContext
    //{
    //    public PasswordContext(string password, int initialLength)
    //    {
    //        Password = password;
    //        InitialLength = initialLength;
    //    }

    //    public string Password { get; }
    //    public int InitialLength { get; }
    //    public int ChangesNeeded { get; set; }
    //}

    //// The handler interface defining the contract for the chain.
    //public interface IPasswordCheckHandler
    //{
    //    void SetNext(IPasswordCheckHandler handler);
    //    void Handle(PasswordContext context);
    //}

    //// Abstract base class for handlers, providing common chain-linking logic.
    //public abstract class PasswordCheckHandler : IPasswordCheckHandler
    //{
    //    protected IPasswordCheckHandler _nextHandler;

    //    public void SetNext(IPasswordCheckHandler handler)
    //    {
    //        _nextHandler = handler;
    //    }

    //    // The main method to be implemented by concrete handlers.
    //    public abstract void Handle(PasswordContext context);

    //    // Helper method to pass the request to the next handler in the chain.
    //    protected void PassToNext(PasswordContext context)
    //    {
    //        _nextHandler?.Handle(context);
    //    }
    //}

    //// Checks if the password contains at least one digit.
    //public class DigitCheckHandler : PasswordCheckHandler
    //{
    //    public override void Handle(PasswordContext context)
    //    {
    //        if (!context.Password.Any(char.IsDigit))
    //        {
    //            context.ChangesNeeded++;
    //        }
    //        PassToNext(context);
    //    }
    //}

    //// Checks if the password contains at least one lowercase letter.
    //public class LowerCaseCheckHandler : PasswordCheckHandler
    //{
    //    public override void Handle(PasswordContext context)
    //    {
    //        if (!context.Password.Any(char.IsLower))
    //        {
    //            context.ChangesNeeded++;
    //        }
    //        PassToNext(context);
    //    }
    //}

    //// Checks if the password contains at least one upper letter.
    //public class UpperCaseCheckHandler : PasswordCheckHandler
    //{
    //    public override void Handle(PasswordContext context)
    //    {
    //        if (!context.Password.Any(char.IsUpper))
    //        {
    //            context.ChangesNeeded++;
    //        }
    //        PassToNext(context);
    //    }
    //}

    //// Checks if the password contains at least one special character.
    //public class SpecialCharCheckHandler : PasswordCheckHandler
    //{
    //    private static readonly HashSet<char> _specialChars =
    //        new HashSet<char>("!@#$%^&*()-+");

    //    public override void Handle(PasswordContext context)
    //    {
    //        if (!context.Password.Any(_specialChars.Contains))
    //        {
    //            context.ChangesNeeded++;
    //        }
    //        PassToNext(context);
    //    }
    //}

    //public class LengthCheckHandler : PasswordCheckHandler
    //{
    //    private const int MinLength = 6;

    //    public override void Handle(PasswordContext context)
    //    {

    //        int missingTypes = context.ChangesNeeded;

    //        int lengthDeficit = MinLength - context.InitialLength;

    //        context.ChangesNeeded = Math.Max(missingTypes, lengthDeficit);

    //        PassToNext(context);
    //    }



    //}
    //public static int MinimumNumber(int n, string password)
    //{
    //    CheckConstraints(n, password);

    //    // Return the minimum number of characters to make the password strong
    //    var context = new PasswordContext(password, n);

    //    var digitCheck = new DigitCheckHandler();
    //    var lowerCheck = new LowerCaseCheckHandler();
    //    var upperCheck = new UpperCaseCheckHandler();
    //    var specialCheck = new SpecialCharCheckHandler();
    //    var lengthCheck = new LengthCheckHandler(); // This must be last

    //    digitCheck.SetNext(lowerCheck);
    //    lowerCheck.SetNext(upperCheck);
    //    upperCheck.SetNext(specialCheck);
    //    specialCheck.SetNext(lengthCheck);

    //    digitCheck.Handle(context);

    //    return context.ChangesNeeded;
    //}
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string password = Console.ReadLine();

        int answer = Result.MinimumNumber(n, password);

        Console.WriteLine(answer);
    }
}
