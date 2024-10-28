# Memento design pattern applied in a text editor
- Memento is a Greek word that means "memory".
- The Memento design pattern is used to implement a text editor that can save and restore its previous state.


This is the diagram that illustrates my implementation:
![Memento Pattern](../../../../public/assets/memento.drawio.svg)

- The `Editor` class is the originator. It has the responsibility of creating the states.
- The `EditorState` class is the memento. It stores the state of the editor.
- The `History` class is the caretaker. It is responsible for the history of the editor.

- The relationship between the `Editor` and `EditorState` classes is **dependency**. Because the editor returns an EditorState object.
- The relationship between the `History` and `Editor` classes is **association**. Because the history has a field of Editor - a list of EditorState objects.
