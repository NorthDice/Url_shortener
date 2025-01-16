import React, { useState, useEffect } from "react";
import "./TableView.css";
import { fetchUrls, addUrl } from "../../services/urls"; 
import Table from "../Table/Table";
import Modal from "../Modal/Modal";
import { useNavigate } from "react-router-dom";

const TableView = () => {
  const [urls, setUrls] = useState([]); 
  const [isModalOpen, setIsModalOpen] = useState(false); 
  const [modalType, setModalType] = useState(""); 
  const [urlInput, setUrlInput] = useState(""); 
  const [isUrlAdded, setIsUrlAdded] = useState(false);  

  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const urlsData = await fetchUrls();
        setUrls(urlsData);  
      } catch (error) {
        console.error("Error fetching URLs:", error);
      }
    };

    fetchData();
  }, [isUrlAdded]);  

  const openAddModal = () => {
    setModalType("add");
    setUrlInput(""); 
    setIsModalOpen(true);
  };

  const openDeleteModal = () => {
    setModalType("delete");
    setUrlInput(""); 
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
    setModalType("");
    setUrlInput(""); 
  };

  const columns = ["id", "originalUrl", "shortenedUrl"]; 

  const handleViewUrlClick = () => {
    navigate("/info"); 
  };

  const handleAddUrl = async () => {
    try {
      const newUrl = await addUrl(urlInput); 
      if (newUrl) {
        setIsUrlAdded(true);  
        closeModal();
      } else {
        console.error("Failed to add URL");
      }
    } catch (error) {
      console.error("Error adding URL:", error);
    }
  };

  return (
    <div className="table-view">
      <div className="table-view__buttons">
        <button className="table-view__button" onClick={openAddModal}>
          Add new URL
        </button>
        <button className="table-view__button" onClick={openDeleteModal}>
          Delete URL
        </button>
        <button className="table-view__button" onClick={handleViewUrlClick}>
          View URL
        </button>
      </div>

      <Modal
        isOpen={isModalOpen}
        title={modalType === "add" ? "Add URL" : modalType === "delete" ? "Delete URL" : "View URL"}
        onConfirm={handleAddUrl} 
        onCancel={closeModal}
      >
        <input
          type="text"
          value={urlInput}
          onChange={(e) => setUrlInput(e.target.value)}
          placeholder={modalType === "add" ? "Enter URL" : "Enter ID to delete"}
        />
      </Modal>

      <div className="table-view__header">
        <h1 className="table-view__title">SHORT TABLE VIEW</h1>
      </div>

      <Table columns={columns} data={urls} />
    </div>
  );
};

export default TableView;
