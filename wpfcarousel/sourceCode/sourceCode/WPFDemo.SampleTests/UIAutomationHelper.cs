using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Automation;

namespace WPFDemo.SampleTests
{
    public static class ExtensionMethods
    {
        public static System.Drawing.Point ToDrawingPoint(this System.Windows.Point windowsPoint)
        {
            return new System.Drawing.Point
            {
                X = Convert.ToInt32(windowsPoint.X),
                Y = Convert.ToInt32(windowsPoint.Y)
            };
        }
    }

    public static class UIAutomationHelper
    {
        public static AutomationElement LaunchApplication(string fileName)
        {
            return LaunchApplication(fileName, "");
        }

        public static AutomationElement LaunchApplication(string fileName, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.Start();
            Thread.Sleep(2000);
            return (AutomationElement.FromHandle(process.MainWindowHandle));
        }

        public static AutomationElementCollection GetElementsByName(AutomationElement window, string name)
        {
            if (window == null)
                return null;

            return GetElements(window, new PropertyCondition(AutomationElement.NameProperty, name));
        }

        public static AutomationElement GetElementByName(AutomationElement window, string name)
        {
            if (window == null)
                return null;

            return GetElement(window, new PropertyCondition(AutomationElement.NameProperty, name));
        }

        public static AutomationElement GetElementById(AutomationElement window, string id)
        {
            if (window == null)
                return null;

            return GetElement(window, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
        }

        public static bool InvokeElementByName(AutomationElement window, string name)
        {
            return InvokeElement(window, new PropertyCondition(AutomationElement.NameProperty, name));
        }

        public static bool InvokeElementById(AutomationElement window, string id)
        {
            return InvokeElement(window, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
        }

        public static bool InvokeElement(AutomationElement window, Condition condition)
        {
            if (window == null)
                return false;

            AutomationElement element = GetElement(window, condition);
            if (element != null)
            {
                InvokePattern pattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                pattern.Invoke();
                return true;
            }

            return false;
        }

        public static bool ExpandElementByName(AutomationElement window, string name)
        {
            return ExpandElement(window, new PropertyCondition(AutomationElement.NameProperty, name));
        }

        public static bool ExpandElementById(AutomationElement window, string id)
        {
            return ExpandElement(window, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
        }


        private static bool ExpandElement(AutomationElement window, Condition condition)
        {
            AutomationElement element = GetElement(window, condition);
            return ExpandElement(element);
        }

        public static bool ExpandElement(AutomationElement element)
        {
            if (element == null)
                return false;

            ExpandCollapsePattern pattern = element.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            pattern.Expand();
            return true;
        }




        internal static void ToggleElementByID(AutomationElement window, string id)
        {
            var element = GetElement(window, new PropertyCondition(AutomationElement.AutomationIdProperty, id));

            TogglePattern pattern = element.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            pattern.Toggle();
        }

        public static void SelectIndexFromDropdown(AutomationElement window, string selectionElementId, int index)
        {
            AutomationElement dropDownItem = UIAutomationHelper.GetElementById(window, selectionElementId);
            
            AutomationElementCollection comboboxItem = dropDownItem.FindAll(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));

            ExpandCollapsePattern expandPattern = (ExpandCollapsePattern)dropDownItem.GetCurrentPattern(ExpandCollapsePattern.Pattern);

            expandPattern.Expand();

            AutomationElement itemToSelect = comboboxItem[index];

            Object selectPattern = null;
            if (itemToSelect.TryGetCurrentPattern(SelectionItemPattern.Pattern, out selectPattern))
            {
                ((SelectionItemPattern)selectPattern).Select();
            }
        }

        public static bool ElementIsSelected(AutomationElement window, string selectionElementId)
        {
            AutomationElement selectionItem = UIAutomationHelper.GetElementById(window, selectionElementId);
            SelectionItemPattern selectionItemPattern = selectionItem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            return selectionItemPattern.Current.IsSelected;
        }

        public static bool ElementIsEnabled(AutomationElement window, string elementId)
        {
            AutomationElement element = UIAutomationHelper.GetElementById(window, elementId);
            return (bool)element.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty);
        }


        public static void SelectElement(AutomationElement window, string selectionElementId)
        {
            AutomationElement selectionItem = UIAutomationHelper.GetElementById(window, selectionElementId);
            SelectionItemPattern selectionItemPattern = selectionItem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            selectionItemPattern.Select();
        }

        public static void SetValue(AutomationElement window, string valueControlName, string newValue)
        {
            AutomationElement textBox = UIAutomationHelper.GetElementById(window, valueControlName);
            ValuePattern valuePattern = textBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            valuePattern.SetValue(newValue);
        }

        public static int GetNumberOfChildElements(AutomationElement window, string elementId)
        {
            AutomationElement element = UIAutomationHelper.GetElementById(window, elementId);
            return element.FindAll(TreeScope.Children, PropertyCondition.TrueCondition).Count;
        }

        public static string GetElementText(AutomationElement window, string id)
        {
            TextPattern pattern = (TextPattern)UIAutomationHelper.GetElementById(window, id).GetCurrentPattern(TextPattern.Pattern);
            return pattern.DocumentRange.GetText(-1);
        }

        public static string GetElementText(AutomationElement elementWithText)
        {
            TextPattern pattern = (TextPattern)elementWithText.GetCurrentPattern(TextPattern.Pattern);
            return pattern.DocumentRange.GetText(-1);
        }

        public static void InvokeElement(AutomationElement elementToInvoke)
        {
            InvokePattern invoke = (InvokePattern)elementToInvoke.GetCurrentPattern(InvokePattern.Pattern);
            invoke.Invoke();
            Thread.Sleep(500);
        }

        public static void InvokeTableCellElement(AutomationElement window, string listViewName, int row, int column)
        {
            AutomationElement grid = UIAutomationHelper.GetElementById(window, listViewName);
            GridPattern gridPattern = grid.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
            AutomationElement cell = gridPattern.GetItem(row, column);

            AutomationElement cellHyperlink = GetFirstChild(cell);

            InvokeElement(cellHyperlink);
        }

        public static AutomationElement GetFirstChild(AutomationElement cell)
        {
            return GetElement(cell, Condition.TrueCondition);
        }

        internal static AutomationElement GetFirstChild(AutomationElement element, string name)
        {
            return GetElement(element, new PropertyCondition(AutomationElement.NameProperty, name));
        }

        public static AutomationElement GetSelectedElement(AutomationElement parent)
        {
            return GetElement(parent, new PropertyCondition(SelectionItemPattern.IsSelectedProperty, true));
        }


        public static DataTable GetDataTableFromListView(AutomationElement window, string listViewName)
        {
            AutomationElement grid = UIAutomationHelper.GetElementById(window, listViewName);
            GridPattern gridPattern = grid.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

            DataTable table = new DataTable();

            for (int i = 0; i < gridPattern.Current.ColumnCount; i++)
            {
                table.Columns.Add(GetColumnHeaderId(gridPattern.GetItem(0, i)));
            }

            for (int i = 0; i < gridPattern.Current.RowCount; i++)
            {
                table.Rows.Add();

                for (int j = 0; j < gridPattern.Current.ColumnCount; j++)
                {
                    AutomationElement cell = gridPattern.GetItem(i, j);
                    string columnName = GetColumnHeaderId(cell);
                    table.Rows[i][columnName] = cell.GetCurrentPropertyValue(AutomationElement.NameProperty);
                }
            }

            return table;
        }

        private static string GetColumnHeaderId(AutomationElement cellElement)
        {
            AutomationElement gridElement = cellElement.GetCurrentPropertyValue(GridItemPatternIdentifiers.ContainingGridProperty) as AutomationElement;
            TablePattern tablePattern = gridElement.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
            int columnIndex = (int)cellElement.GetCurrentPropertyValue(GridItemPatternIdentifiers.ColumnProperty);
            AutomationElement headerElement = tablePattern.Current.GetColumnHeaders()[columnIndex];
            return (string)headerElement.GetCurrentPropertyValue(AutomationElement.NameProperty);
        }



        public static void SelectElement(AutomationElement elementToSelect)
        {
            SelectionItemPattern pattern = elementToSelect.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            pattern.Select();
        }

        public static void AddElementToSelection(AutomationElement elementToSelect)
        {
            SelectionItemPattern pattern = elementToSelect.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            pattern.AddToSelection();
        }


        public static void PerformMouseClickOnItem(AutomationElement window, string elementId)
        {
            try
            {
                var element = UIAutomationHelper.GetElementById(window, elementId);

                Mouse.Click(GetPointToClick(element));
                return;

                //System.Windows.Point hit;
                //bool result = element.TryGetClickablePoint(out hit);
                //Mouse.Click(new Point((int)hit.X, (int)hit.Y));
                //return;

                //int x = (int)element.GetClickablePoint().X;
                //int y = (int)element.GetClickablePoint().Y;
                //Point target = new Point(x, y);
                //Mouse.Click(target);
            }
            catch (NoClickablePointException)
            {
                // clean up this into a finite recursive call...
                var element = UIAutomationHelper.GetElementById(window, elementId);
                int x = (int)element.GetClickablePoint().X;
                int y = (int)element.GetClickablePoint().Y;
                Point target = new Point(x, y);
                Mouse.Click(target);
            }
        }

        public static void PerformRightMouseClickOnItem(AutomationElement window, string elementId)
        {
            AutomationElement element = null;
            try
            {
                element = UIAutomationHelper.GetElementById(window, elementId);
                RightClickOnElement(element);
            }
            catch (NoClickablePointException)
            {
                // clean up this into a finite recursive call...
                element = UIAutomationHelper.GetElementById(window, elementId);
                RightClickOnElement(element);
            }
        }

        public static void RightClickOnElement(AutomationElement element)
        {
            Mouse.RightClick(GetPointToClick(element));
        }
        private static System.Drawing.Point GetPointToClick(AutomationElement element)
        {
            return new System.Windows.Point(
                 element.Current.BoundingRectangle.Left + 10,
                 element.Current.BoundingRectangle.Top + 10).ToDrawingPoint();
        }



        private const int ELEMENT_SEARCH_TIMEOUT_SECONDS = 10;

        private static AutomationElement GetElement(AutomationElement window, Condition condition)
        {
            DateTime startTime = DateTime.Now;
            AutomationElement element = null;
            do
            {
                element = window.FindFirst(TreeScope.Descendants, condition);

                if (element == null)
                {
                    Thread.Sleep(500);
                }

                if ((DateTime.Now - startTime).TotalSeconds > ELEMENT_SEARCH_TIMEOUT_SECONDS)
                    throw new TimeoutException("Searching for an element took longer than specified timeout of " + ELEMENT_SEARCH_TIMEOUT_SECONDS + " seconds");
            }
            while (element == null);

            return element;
        }

        private static AutomationElementCollection GetElements(AutomationElement window, Condition condition)
        {
            return window.FindAll(TreeScope.Descendants, condition);
        }


        public static bool ElementDoesNotExist(AutomationElement window, string name)
        {
            try
            {
                AutomationElement element = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, name));
                return element == null;
            }
            catch
            {
                return false;
            }
        }

        public static bool ElementExists(AutomationElement window, string id)
        {
            try
            {
                AutomationElement element = GetElement(window, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
                return element != null;
            }
            catch
            {
                return false;
            }
        }



        internal static string GetElementName(AutomationElement window, string id)
        {
            return UIAutomationHelper.GetElementById(window, id).Current.Name;
        }
    }



}
