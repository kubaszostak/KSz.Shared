﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace System.Windows.Documents
{

    public static class FlowDocEx
    {
        public static Inline AddLine(this Paragraph par, string text)
        {
            var res = par.Add(text);
            par.Inlines.Add(new LineBreak());
            return res;
        }

        public static Inline Add(this Paragraph par, string text)
        {
            par.Inlines.Add(text);
            return par.Inlines.LastInline;
        }

        public static Paragraph AddParagraph(this FlowDocument doc, string text)
        {
            var par = new Paragraph();
            par.Inlines.Add(text);
            doc.Blocks.Add(par);
            return par;
        }

        public static void SetErrorFormating(this TextElement el)
        {
            el.Foreground = new SolidColorBrush(Colors.Maroon);
            el.FontWeight = FontWeights.Bold;
        }


        public static Section AddPageBreak(this FlowDocument flowDoc)
        {
            Section section = new Section();
            section.BreakPageBefore = true;
            flowDoc.Blocks.Add(section);
            return section;
        }

        public static void AddClickAction(this FrameworkContentElement element, Action action, string tooltip = null)
        {
            element.Cursor = Cursors.Hand;
            element.ToolTip = tooltip;
            element.MouseLeftButtonDown += (s, e) =>
            {
                action();
            };
        }

        public static void OpenPathOnClick(this FrameworkContentElement element, string path, string tooltip = null)
        {
            element.AddClickAction(() => Process.Start(path), tooltip);
        }
    }
}
