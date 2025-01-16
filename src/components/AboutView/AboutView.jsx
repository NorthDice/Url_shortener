import React from 'react';
import './AboutView.css'; 

const AboutView = () => {
  return (
    <div className="about-container">
      <h1 className="main-heading">Welcome to URL Shortener</h1>
      <p className="intro-text">
        A powerful and user-friendly service designed to simplify your online sharing experience. 
        We take long URLs and transform them into sleek, shareable links that are easy to manage and distribute.
      </p>
      <div className="how-it-works">
        <h2 className="section-heading">How It Works</h2>
        <p className="paragraph-text">
          Our algorithm creates a unique, random short code for every URL you submit. 
          We ensure no duplicates by checking each code against our database to guarantee it’s one-of-a-kind. 
          This means your shortened URL will never collide with another.
        </p>
      </div>
      <div className="features">
        <h3 className="section-heading">Key Features:</h3>
        <ul className="feature-list">
          <li>🌟 Customizable short links</li>
          <li>⚡ Fast URL shortening with instant results</li>
          <li>🔒 Guaranteed unique codes to avoid conflicts</li>
        </ul>
      </div>
      <div className="cta">
        <p className="cta-text">
          Ready to shorten your URLs? Start now and make sharing simpler than ever!
        </p>
      </div>
    </div>
  );
};

export default AboutView;
