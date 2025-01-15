import React from 'react'
import "./Header.css"
import {logo} from "../../assets/logo.png"

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
                <li className="nav-list__item"><a className="nav-list__link" href="">TABLE VIEW</a></li>
                <li className="nav-list__item"><a className="nav-list__link" href="">INFO VIEW</a></li>
                <li className="nav-list__item"><a className="nav-list__link" href="">ABOUT VIEW</a></li>
            </ul>
        </nav>

        <div className="action-section">
            <a className="action-section__item">NEW ACCOUNT</a>
            <a className="action-section__item">SIGN IN</a>
        </div>

    </header>
  )
}
