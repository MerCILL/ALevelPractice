using Module3HM6_ContactListApp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HM6_ContactListApp.Services
{
    public class ContactTrie
    {
        private class TrieNode
        {
            public ConcurrentDictionary<char, TrieNode> Children = new ConcurrentDictionary<char, TrieNode>();
            public Contact Contact;
        }

        private readonly TrieNode _root = new TrieNode();

        public void Insert(string key, Contact contact)
        {
            var node = _root;
            foreach (var ch in key)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.Contact = contact;
        }

        public Contact Search(string key)
        {
            var node = _root;
            foreach (var ch in key)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return null;
                }
                node = node.Children[ch];
            }
            return node.Contact;
        }

        public void Remove(string key)
        {
            Remove(_root, key, 0);
        }

        private bool Remove(TrieNode current, string key, int index)
        {
            if (index == key.Length)
            {
                if (current.Contact == null)
                {
                    return false;
                }
                current.Contact = null;
                return current.Children.Count == 0;
            }
            char ch = key[index];
            TrieNode node;
            if (!current.Children.TryGetValue(ch, out node))
            {
                return false;
            }
            bool shouldDeleteCurrentNode = Remove(node, key, index + 1) && node.Contact == null;
            if (shouldDeleteCurrentNode)
            {
                current.Children.TryRemove(ch, out _);
                return current.Children.Count == 0;
            }
            return false;
        }

        public ConcurrentDictionary<string, Contact> SearchContacts(string prefix)
        {
            try
            {
                if (!prefix.StartsWith("+"))
                {
                    prefix = "+" + prefix;
                }

                var result = new ConcurrentDictionary<string, Contact>();
                var node = _root;

                foreach (var ch in prefix)
                {
                    if (!node.Children.ContainsKey(ch))
                    {
                        return result;
                    }
                    node = node.Children[ch];
                }

                FindAllContacts(node, result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Searching contacts error: {ex.Message}");
                return null;
            }
        }


        private void FindAllContacts(TrieNode node, ConcurrentDictionary<string, Contact> result)
        {
            if (node.Contact != null)
            {
                result[node.Contact.Phone] = node.Contact;
            }

            foreach (var child in node.Children.Values)
            {
                FindAllContacts(child, result);
            }
        }

        public bool Contains(string key)
        {
            var node = _root;
            foreach (var ch in key)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return false;
                }
                node = node.Children[ch];
            }
            return node.Contact != null;
        }

    }
}
