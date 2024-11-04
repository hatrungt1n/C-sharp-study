using DesignPatterns.Behavioral.Memento;

var editor = new Editor();
var history = new History(editor);

editor.Title = "Title 1";
editor.Content = "Content 1";
history.Backup();

editor.Title = "Title 2";
editor.Content = "Content 2";
history.Backup();

history.ShowHistory();

System.Console.WriteLine(editor.Title);
System.Console.WriteLine(editor.Content);

history.Undo();

System.Console.WriteLine(editor.Title);
System.Console.WriteLine(editor.Content);

history.Undo();

history.ShowHistory();

