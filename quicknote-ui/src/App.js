import 'bootstrap/dist/css/bootstrap.min.css';
import { useState, useContext } from 'react';
import './App.css';
import NoteBook from './Notebook'
import Enterance from './Enterance'
import AppContext from './AppContext';



function App() {
  const [noteBook, setNoteBook] = useState(null);

  return (


    <AppContext.Provider value={{noteBook, setNoteBook}}>
      <div className="App w-100 h-100 ">
        {noteBook ? <NoteBook /> : <Enterance />}
        
      </div> 
    </AppContext.Provider>

  );
}

export default App;
