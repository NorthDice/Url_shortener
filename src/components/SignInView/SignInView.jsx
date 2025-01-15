import React from 'react'
import './SignInView.css';

const SignInView = () => {
  return (
    <div className="sign-in-container">
    <h1 className="sign-in-title">Sign In</h1>
    <form className="sign-in-form">
      <div className="form-group">
        <label htmlFor="email" className="form-label">Email:</label>
        <input
          type="email"
          id="email"
          className="form-input"
          required
        />
      </div>

      <div className="form-group">
        <label htmlFor="password" className="form-label">Password:</label>
        <input
          type="password"
          id="password"
          className="form-input"
          required
        />
      </div>

      <button type="submit" className="form-button">Sign In</button>
    </form>
  </div>
  )
}

export default SignInView
