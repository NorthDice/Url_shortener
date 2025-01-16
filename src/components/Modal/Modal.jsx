import React from "react";
import "./Modal.css";

const Modal = ({ isOpen, title, onConfirm, onCancel, children }) => {
  if (!isOpen) return null;

  return (
    <div className="modal">
      <div className="modal__content">
        <h3>{title}</h3>
        <div className="modal__body">{children}</div>
        <div className="modal__buttons">
          <button onClick={onConfirm}>Confirm</button>
          <button onClick={onCancel}>Cancel</button>
        </div>
      </div>
    </div>
  );
};

export default Modal;
