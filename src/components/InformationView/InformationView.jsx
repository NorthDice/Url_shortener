import React from 'react'
import { useState,useEffect } from 'react';
import { fetchUrls } from '../../services/urls';
import Table from '../Table/Table';
import "./InformationView.css"

const InformationView = () => {
  const [urls, setUrls] = useState([])
  
      useEffect(() => {
          const fetchData = async () => {
              let urlsData  = await fetchUrls()
              setUrls(urlsData)
          };
  
          fetchData()
      }, [])
  
      const columns = ['id', 'userId', 'shortenedUrl', 'createdAt'];

  return (
    <>
          <div className="table__header">
              <h1 className="table-view__title">INFORMATION TABLE VIEW</h1>
          </div>
          <div className="table-container">

          <Table
              columns={columns}
              data={urls.map((url) => ({
                ...url,
                userId: parseInt(url.userId.split('-')[0], 16),
                createdAt: new Date(url.createdAt).toLocaleDateString('en-US', {
                  year: 'numeric',
                      month: '2-digit',
                      day: '2-digit',
                      hour: '2-digit',
                      minute: '2-digit',
                      second: '2-digit',
                      hour12: false, 
                }),
              }))}
            />
          </div>
    </>
  )
}

export default InformationView
