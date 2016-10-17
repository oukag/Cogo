using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cogo.Models;

namespace Cogo.Services.Impl
{
    public class MockIdGenerator : IdGenerator
    {
        private bool alphanumeric;
        private string lastId;
        private int length;

        public MockIdGenerator()
        {
            alphanumeric = false;
            lastId = "000000";
            length = 6;
        }

        public string getNextId()
        {
            string next = incrementId();
            setLastId(next);
            return next;
        }

        private string incrementId()
        {
            String id = "";
            bool increment = true;
            for (int i = length - 1; i >= 0; i--)
            {
                //char c = incrementChar(getLastId()[i]);
                char c = getLastId()[i];
                if (increment)
                {
                    c = incrementChar(getLastId()[i]);
                    if (c != '0')
                    {
                        increment = false;
                    }
                }
                id = c + id;
            }
            return id;
        }

        private char incrementChar(char c)
        {
            if (isAlphanumeric())
            {
                switch (c)
                {
                    case '0':
                        return '1';
                    case '1':
                        return '2';
                    case '2':
                        return '3';
                    case '3':
                        return '4';
                    case '4':
                        return '5';
                    case '5':
                        return '6';
                    case '6':
                        return '7';
                    case '7':
                        return '8';
                    case '8':
                        return '9';
                    case '9':
                        return 'A';
                    case 'A':
                        return 'B';
                    case 'B':
                        return 'C';
                    case 'C':
                        return 'D';
                    case 'D':
                        return 'E';
                    case 'E':
                        return 'F';
                    case 'F':
                        return 'G';
                    case 'G':
                        return 'H';
                    case 'H':
                        return 'I';
                    case 'I':
                        return 'J';
                    case 'J':
                        return 'K';
                    case 'K':
                        return 'L';
                    case 'L':
                        return 'M';
                    case 'M':
                        return 'N';
                    case 'N':
                        return 'O';
                    case 'O':
                        return 'P';
                    case 'P':
                        return 'Q';
                    case 'Q':
                        return 'R';
                    case 'R':
                        return 'S';
                    case 'S':
                        return 'T';
                    case 'T':
                        return 'U';
                    case 'U':
                        return 'V';
                    case 'V':
                        return 'W';
                    case 'W':
                        return 'X';
                    case 'X':
                        return 'Y';
                    case 'Y':
                        return 'Z';
                    default:
                        return '0';
                }
            }
            else
            {
                switch (c)
                {
                    case '0':
                        return '1';
                    case '1':
                        return '2';
                    case '2':
                        return '3';
                    case '3':
                        return '4';
                    case '4':
                        return '5';
                    case '5':
                        return '6';
                    case '6':
                        return '7';
                    case '7':
                        return '8';
                    case '8':
                        return '9';
                    default:
                        return '0';
                }
            }
        }

        public bool isAlphanumeric()
        {
            return alphanumeric;
        }

        public void setAlphanumeric(bool alphanumeric)
        {
            this.alphanumeric = alphanumeric;
        }

        public string getLastId()
        {
            return lastId;
        }

        public void setLastId(string lastId)
        {
            this.lastId = lastId;
            setLength(lastId.Length);
        }

        public int getLength()
        {
            return length;
        }

        public void setLength(int length)
        {
            this.length = length;
        }
    }
}