using System;
using PrefixTree;

internal class Demo {

  private static void Main(string[] args) {
    Trie trie = new Trie();
    trie.Add("hell");
    trie.Add("hello");
    trie.Add("help");
    trie.Add("swag");
    trie.Add("swagger");
    trie.Add("trillswag");
    trie.Add("trillswagyolo");
    foreach(string word in trie.Find("hel", 10)) //We only want 10 maximum results back
	{	
      Console.WriteLine(word);
	}
  }
}