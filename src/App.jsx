import { useState,useEffect } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Header from './components/Header/Header'
import TableView from './components/TableView/TableView'
import { fetchUrls } from './services/urls'

function App() {
  const [count, setCount] = useState(0)
  useEffect(() => {
    const fetchData = async () => {
      await fetchUrls();
    };

    fetchData();
  }, []);

  return (
      <div className="App__item">
        <Header/>
        <TableView/>
      </div>
    
  )
}

export default App
