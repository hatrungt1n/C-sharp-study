namespace DesignPatterns.Behavioral.Memento;

public class History
{
   private List<EditorState> _states = new List<EditorState>();

   private Editor _editor;

   public History(Editor editor) {
    _editor = editor;
   }

   public void Backup() {
    _states.Add(_editor.CreateState());
   }

   public void Undo() {
    if (_states.Count == 0) {
      return;
    }

    var lastState = _states.Last();
    _states.Remove(lastState);
    _editor.RestoreState(lastState);
   }

   public void ShowHistory() {
    System.Console.WriteLine("History: ");
    foreach (var state in _states) {
      System.Console.WriteLine(state.GetName());
    }
   }
}