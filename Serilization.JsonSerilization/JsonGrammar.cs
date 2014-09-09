// <copyright file="JsonGrammar.cs" company="jn">
//     Copyright (c) . All rights reserved.
// </copyright>
// <author>Fang Jing</author>
namespace Serilization.JsonSerilization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// JSON Type.
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// JSON array.
        /// </summary>
        JsonArray,

        /// <summary>
        /// JSON object.
        /// </summary>
        JsonObject,

        /// <summary>
        /// JSON key-value.
        /// </summary>
        JsonKeyValue,

        /// <summary>
        /// JSON Type.
        /// </summary>
        Json,
    }

    /// <summary>
    /// analysis of JSON grammar.
    /// </summary>
    public class JsonGrammar
    {
        /// <summary>
        /// Create abstract grammar tree by bottom up.
        /// </summary>
        /// <param name="tokens">Stack of tokens.</param>
        /// <returns>JSON abstract grammar tree.</returns>
        public static Stack<object> BuildAST(Stack<object> tokens)
        {
            Stack<object> symbols = new Stack<object>();
            Stack<object> temp = new Stack<object>();
            while (tokens.Count > 0)
            {
                object token = tokens.Pop();
                if (token.Equals(Symbol.OpenBracker))
                {
                    while (symbols.Count > 0)
                    {
                        var tempValue = symbols.Pop();
                        if (tempValue.Equals(Symbol.CloseBracker))
                        {
                            symbols.Push(ParseArray(temp));
                            break;
                        }
                        else
                        {
                            temp.Push(tempValue);
                        }
                    }
                }
                else if (token.Equals(Symbol.OpenBrace))
                {
                    while (symbols.Count > 0)
                    {
                        var tempValue = symbols.Pop();
                        if (tempValue.Equals(Symbol.CloseBrace))
                        {
                            symbols.Push(ParseObject(temp));
                            break;
                        }
                        else
                        {
                            temp.Push(tempValue);
                        }
                    }
                }
                else if (token.Equals(Symbol.Colon))
                {
                    symbols.Push(ParseKeyValue((string)tokens.Pop(), symbols.Pop()));
                }
                else
                {
                    symbols.Push(token);
                }
            }

            return symbols;
        }

        /// <summary>
        /// Analysis JSON object.
        /// </summary>
        /// <param name="tokens">Stack of tokens.</param>
        /// <returns>JSON Object Node.</returns>
        public static ObjectNode ParseObject(Stack<object> tokens)
        {
            ObjectNode jsonObject = new ObjectNode();
            while (tokens.Count > 0)
            {
                jsonObject.JsonKeyValue.Add((KeyValueNode)tokens.Pop());
            }

            return jsonObject;
        }

        /// <summary>
        /// Analysis JSON array.
        /// </summary>
        /// <param name="tokens">stack of token.</param>
        /// <returns>JSON Array Node</returns>
        public static ArrayNode ParseArray(Stack<object> tokens)
        {
            ArrayNode jsonArray = new ArrayNode();
            while (tokens.Count > 0)
            {
                jsonArray.JsonArray.Add(tokens.Pop());
            }

            return jsonArray;
        }

        /// <summary>
        /// analysis JSON key-value pairs.
        /// </summary>
        /// <param name="key">key of pairs.</param>
        /// <param name="value">value of pairs.</param>
        /// <returns>JSON key-value Node</returns>
        public static KeyValueNode ParseKeyValue(string key, object value)
        {
            KeyValueNode jsonKeyValue = new KeyValueNode();

            jsonKeyValue.Key = key;
            jsonKeyValue.Value = value;
            return jsonKeyValue;
        }
    }

    /// <summary>
    /// JSON Base Node
    /// </summary>
    public abstract class JsonNode
    {
        /// <summary>
        /// Gets JSON node type.
        /// </summary>
        public virtual NodeType NodeType
        {
            get
            {
                return NodeType.Json;
            }
        }
    }

    /// <summary>
    /// Key Value Node 
    /// key : value
    /// </summary>
    public class KeyValueNode : JsonNode
    {
        /// <summary>
        /// Gets or sets key-value pair of key.
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets key-value pair of value.
        /// </summary>
        public object Value
        {
            get;
            set;
        }

        /// <summary>
        /// JSON node type.
        /// </summary>
        public override NodeType NodeType
        {
            get
            {
                return NodeType.JsonKeyValue;
            }
        }
    }

    /// <summary>
    /// Object Node.
    /// {...}
    /// </summary>
    public class ObjectNode : JsonNode
    {
        /// <summary>
        /// JSON key-value.
        /// </summary>
        private List<KeyValueNode> jsonKeyValue;

        /// <summary>
        /// Gets or sets JSON key-value.
        /// </summary>
        public List<KeyValueNode> JsonKeyValue
        {
            get
            {
                if (this.jsonKeyValue == null)
                {
                    this.jsonKeyValue = new List<KeyValueNode>();
                }

                return this.jsonKeyValue;
            }

            set
            {
                this.jsonKeyValue = value;
            }
        }

        /// <summary>
        /// JSON node type.
        /// </summary>
        public override NodeType NodeType
        {
            get
            {
                return NodeType.JsonObject;
            }
        }
    }

    /// <summary>
    /// Array Node
    /// [...]
    /// </summary>
    public class ArrayNode : JsonNode
    {
        /// <summary>
        /// Gets or sets JSON Array.
        /// </summary>
        private List<object> jsonArray;

        /// <summary>
        /// Gets or sets JSON Array.
        /// </summary>
        public List<object> JsonArray
        {
            get
            {
                if (this.jsonArray == null)
                {
                    this.jsonArray = new List<object>();
                }

                return this.jsonArray;
            }

            set
            {
                this.jsonArray = value;
            }
        }

        /// <summary>
        /// JSON node type.
        /// </summary>
        public override NodeType NodeType
        {
            get
            {
                return NodeType.JsonArray;
            }
        }
    }
}
