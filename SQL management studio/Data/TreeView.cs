namespace SQL_management_studio.Data
{
    public class TreeView
    {
        public bool expanded = false;
        public string ParentTreeview { get; set; }
        public string[] ChildTreeview;
        public TreeView[] Treeview;
        public TreeView(string ParentTreeview, TreeView[] treeView, string[] ChildTreeview)
        {
            this.ParentTreeview = ParentTreeview;
            this.Treeview = treeView;
            this.ChildTreeview = ChildTreeview;
        }
        public void toggle()
        {
            expanded = !expanded;
        }
        public string getIcon()
        {
            if (expanded)
            {
                return "-";
            }
            return "+";
        }
    }
}
