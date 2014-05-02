using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace PrefixTree
{
    public class Trie
    {
        public TrieNode RootNode
        {
            get;
            private set;
        }

        public Trie()
        {
            RootNode = new TrieNode
            { 
                Letter = TrieNode.Root
            };
        }

        public void Add(string word)
        {
            word = word.ToLower() + TrieNode.endWord;
            var currentNode = RootNode;
            foreach (var letter in word)
            {
                currentNode = currentNode.AddChild(letter);
            }
        }

        public List<string> Find(string prefix, int? maxMatches)
        {
            prefix = prefix.ToLower();

            var set = new HashSet<string>();

            FindRecursive(RootNode, set, "", prefix, maxMatches);
            return set.ToList();
        }

        private static void FindRecursive(TrieNode node, ISet<string> results, string letters, string prefix, int? maxResults)
        {
            if (maxResults != null && results.Count == maxResults)
            {
                return;
            }

            if (node == null)
            {
                if (!results.Contains(letters))
                {
                    results.Add(letters);
                    return;
                }
            }

            letters += node.Letter.ToString();

            if (prefix.Length > 0)
            {
                if (node.ContainsKey(prefix[0]))
                {
                    FindRecursive(node[prefix[0]], results, letters, prefix.Remove(0, 1), maxResults);
                }
            }
            else
            {
                foreach (char key in node.Keys)
                {
                    FindRecursive(node[key], results, letters, prefix, maxResults);
                }
            }
        }
    }
}