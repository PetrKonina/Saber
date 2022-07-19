using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saber
{
    public class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
            Dictionary<ListNode, int> dictionary = new Dictionary<ListNode, int>();
            int i = 0;
            Random randomIndex = new Random();
            for (ListNode currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                dictionary.Add(currentNode, i++);
                currentNode.Random = SaveLinkToRandomElement(randomIndex.Next(0, Count));
            }

            var currentNodeElement = Head;
            using StreamWriter sw = new StreamWriter(s);
            while (currentNodeElement != null)
            {
                sw.WriteLine($"Node data = {currentNodeElement.Data} && Random Index = {dictionary[currentNodeElement.Random]}");
                currentNodeElement = currentNodeElement.Next;
            }
        }

        private ListNode SaveLinkToRandomElement(int indexOfRandomElementLink)
        {
            var linkToElement = Head;

            if (indexOfRandomElementLink > (Count / 2))
            {
                linkToElement = Tail;
                for (int i = Count - 1; i > 0; i--)
                {
                    if (i == indexOfRandomElementLink)
                    {
                        break;
                    }
                    linkToElement = linkToElement.Previous;
                }
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (i == indexOfRandomElementLink)
                    {
                        break;
                    }
                    linkToElement = linkToElement.Next;
                }
            }
            return linkToElement;
        }

        public void Deserialize(Stream s)
        {
            using StreamReader sr = new StreamReader(s);
            string lineToDeserialize;
            while ((lineToDeserialize = sr.ReadLine()) != null)
            {
                var splittedLine = lineToDeserialize.Split("&&");
                var dataLine = splittedLine[0];
                AddNewNode(dataLine);
            }
        }

        public void AddNewNode(string data)
        {
            ListNode newNode = new ListNode();
            if (Head != null)
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
            }
            else
            {
                Head = newNode;
            }
            newNode.Data = data;
            Tail = newNode;
            Count++;
        }
    }
}
