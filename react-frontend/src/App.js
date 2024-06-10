import './App.css';
import { Route, Routes } from 'react-router-dom';
import Homepage from './Components/Pages/Homepage';
import Librarypage from './Components/Pages/Librarypage';
import Bookpage from './Components/Pages/Bookpage';
import LibraryFormPage from './Components/Pages/LibraryFormPage';
import BookFormPage from './Components/Pages/BookFormPage';
import Header from './Components/Organisms/Header';

function App() {
  return (
    <div className="App">
      <Header />
      <Routes>
        <Route path="/" element = {< Homepage/>}/>
        <Route path="/libraries" element = {< Librarypage/>}/>
        <Route path="/books" element = {< Bookpage/>}/>
        <Route path="/addLibrary" element = {< LibraryFormPage/>}/>
        <Route path="/addBook" element = {< BookFormPage edit={false} />}/>
        <Route path="/editbook" element = {< BookFormPage edit={true} />}/>
      </Routes>
    </div>
  );
}

export default App;
