// <copyright file="JsonLatex.cs" company="jn">
//     Copyright (c) jn. All rights reserved.
// </copyright>
// <author>Fang Jing</author>
namespace Serilization.JsonSerilization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// enumerate of JSON special tokens.
    /// </summary>
    public enum Symbol
    {
        /// <summary>
        /// representation of '{'.
        /// </summary>
        OpenBrace,

        /// <summary>
        /// representation of '}'.
        /// </summary>
        CloseBrace,

        /// <summary>
        /// representation of '['.
        /// </summary>
        OpenBracker,

        /// <summary>
        /// representation of ']'.
        /// </summary>
        CloseBracker,

        /// <summary>
        /// representation of ':'.
        /// </summary>
        Colon,

        /// <summary>
        /// representation of semicolon ','.
        /// </summary>
        Semicolon,
    }

    /// <summary>
    /// JSON latex analysis.
    /// </summary>
    public class JsonLatex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonLatex"/> class.
        /// </summary>
        public JsonLatex()
        {
            this.Tokens = new Stack<object>();
        }

        /// <summary>
        /// Gets or sets stack of Tokens.
        /// </summary>
        public Stack<object> Tokens
        {
            get;
            set;
        }

        /// <summary>
        /// scan string.
        /// </summary>
        /// <param name="jsonString">JSON string.</param>
        public void Scanner(string jsonString)
        {
            for (int i = 0; i < jsonString.Length; i = i + 1)
            {
                char ch = jsonString[i];
                StringBuilder sb = new StringBuilder();
                switch (ch)
                {
                    case '{':
                        this.Tokens.Push(Symbol.OpenBrace);
                        break;
                    case '}':
                        this.Tokens.Push(Symbol.CloseBrace);
                        break;
                    case '[':
                        this.Tokens.Push(Symbol.OpenBracker);
                        break;
                    case ']':
                        this.Tokens.Push(Symbol.CloseBracker);
                        break;
                    case ',':
                        /*this.Tokens.Push(Symbol.Semicolon);*/
                        break;
                    case '"':
                        sb = new StringBuilder();
                        i = i + 1;
                        ch = jsonString[i];
                        char prech = ' ';
                        while (ch != '"' || prech == '\\')
                        {
                            sb.Append(ch);
                            i = i + 1;
                            ch = jsonString[i];
                            prech = jsonString[i - 1];
                        }

                        this.Tokens.Push(sb.ToString());
                        break;

                    case ':':
                        this.Tokens.Push(Symbol.Colon);
                        break;
                    /*消除多余的符号*/
                    case ' ':
                    case '\n':
                    case '\t':
                    case '\r':
                        break;
                    case '-':
                        sb = new StringBuilder(ch);
                        if (char.IsDigit(ch))
                        {
                            while (char.IsDigit(ch))
                            {
                                sb.Append(ch);
                                i = i + 1;
                                ch = jsonString[i];
                            }
                        }

                        this.Tokens.Push(sb.ToString());
                        break;
                    default:
                        sb = new StringBuilder();
                        if (char.IsDigit(ch))
                        {
                            while (char.IsDigit(ch))
                            {
                                sb.Append(ch);
                                i = i + 1;
                                ch = jsonString[i];
                            }
                        }
                        else if (char.IsLetter(ch))
                        {
                            while (char.IsLetter(ch))
                            {
                                sb.Append(ch);
                                i = i + 1;
                                ch = jsonString[i];
                            }
                        }

                        this.Tokens.Push(sb.ToString());
                        break;
                }
            }
        }
    }
}