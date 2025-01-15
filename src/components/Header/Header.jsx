import React from 'react'
import "./Header.css"
import logo from "../../assets/logo.png"
import { Link } from 'react-router-dom';

export default function Header() {
    

    return (
    <header className="header">
        <div className="logo-section">
            <a className="logo__item"></a>
                <img className="image__item"
                    src={logo}
                    alt="shorten-url"
                />
            <p className="paragraph__item">SHORTEN URL</p>
        </div>

        <nav className="header__nav">
            <ul className="nav-list">
                <li className="nav-list__item"><Link className="nav-list__link" to="/table">TABLE VIEW</Link></li>
                <li className="nav-list__item"><Link className="nav-list__link" to="/info">INFO VIEW</Link></li>
                <li className="nav-list__item"><Link className="nav-list__link" to="/about">ABOUT VIEW</Link></li>
            </ul>
        </nav>

        <div className="action-section">
            <Link className="action-section__item" to="/newAccount">NEW ACCOUNT</Link>
            <Link className="action-section__item" to="/signIn">SIGN IN</Link>
        </div>

    </header>
  )
}
