import { useState,useEffect } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Header from './components/Header/Header'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import TableView from './components/TableView/TableView'
import { fetchUrls } from './services/urls'
import InformationView from './components/InformationView/InformationView'
import AboutView from './components/AboutView/AboutView'
import NewAccountView from './components/NewAccountView/NewAccountView'
import SignInView from './components/SignInView/SignInView'

function App() {
  
  return (
      <div className="App__item">
        <Header />
      <Routes>
        <Route path="/table" element={<TableView />} />
        <Route path="/info" element={<InformationView />} />
        <Route path="/about" element={<AboutView />} />
        <Route path="/newAccount" element={<NewAccountView />} />
        <Route path="/signIn" element={<SignInView />} />
      </Routes>
      </div>
    
  )
}

export default App
