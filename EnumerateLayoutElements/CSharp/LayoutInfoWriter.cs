﻿using System;

using Aspose.Words.Layout;

namespace EnumerateLayoutElements
{
    class LayoutInfoWriter
    {
        public static void Run(LayoutEnumerator it)
        {
            DisplayLayoutElements(it, string.Empty);
        }

        /// <summary>
        /// Enumerates forward through each layout element in the document and prints out details of each element. 
        /// </summary>
        private static void DisplayLayoutElements(LayoutEnumerator it, string padding)
        {
            do
            {
                DisplayEntityInfo(it, padding);

                if (it.MoveFirstChild())
                {
                    // Recurse into this child element.
                    DisplayLayoutElements(it, AddPadding(padding));
                    it.MoveParent();
                }
            } while (it.MoveNext());
        }

        /// <summary>
        /// Displays information about the current layout entity to the console.
        /// </summary>
        private static void DisplayEntityInfo(LayoutEnumerator it, string padding)
        {
            Console.Write(padding + it.Type + " - " + it.Kind);

            if (it.Type == LayoutEntityType.Span)
                Console.Write(" - " + it.Text);

            Console.WriteLine();
        }

        /// <summary>
        /// Returns a string of spaces for padding purposes.
        /// </summary>
        private static string AddPadding(string padding)
        {
            return padding + new string(' ', 4);
        }
    }
}