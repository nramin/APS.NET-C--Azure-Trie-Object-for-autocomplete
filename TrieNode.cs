using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace PrefixTree
{
    public class TrieNode
    {
        public const char Root = ' ';
        public const char endWord = '$';

        public char Letter
        {
            get;
            set;
        }

        public HybridDictionary Children
        {
            get;
            private set;
        }

        public TrieNode()
        {
        
        }

        public TrieNode(char letter)
        {
            this.Letter = letter;
        }

        public TrieNode this[char index]
        {
            get {
                return (TrieNode)Children[index];
            }
        }

        public ICollection Keys
        {
            get
            {
                return Children.Keys;
            }
        }

        public bool ContainsKey(char key)
        {
            return Children.Contains(key);
        }

        public TrieNode AddChild(char letter)
        {
            if (Children == null)
            {
                Children = new HybridDictionary();
            }

            if (!Children.Contains(letter))
            {
                if (letter != endWord)
                {
                    var node = new TrieNode(letter);
                    Children.Add(letter, node);
                    return node;
                }
                else
                {
                    Children.Add(letter, null);
                    return null;
                }
            }

            return (TrieNode)Children[letter];
        }

        public override string ToString()
        {
            return this.Letter.ToString();
        }
    }
}