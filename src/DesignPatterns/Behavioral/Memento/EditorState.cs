namespace DesignPatterns.Behavioral.Memento;

public class EditorState
{
  private readonly string _title;

  private readonly string _content;

  private readonly DateTime _createdAt;

  public EditorState(string title, string content) {
    _title = title;
    _content = content;
    _createdAt = DateTime.Now;
  }

  public string GetTitle() => _title;

  public string GetContent() => _content;

  public DateTime GetCreatedAt() => _createdAt;

  public string GetName() => $"{_title} - {_createdAt}";
}