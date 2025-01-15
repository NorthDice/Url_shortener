import React from 'react'
import './TableView.css'
import { useState,useEffect } from 'react'
import { fetchUrls } from '../../services/urls'
import Table from '../Table/Table'


const TableView = () => {
    const [urls, setUrls] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            let urlsData  = await fetchUrls()
            setUrls(urlsData)
        };

        fetchData()
    }, [])

    const columns = ['id', 'originalUrl', 'shortenedUrl'];
    return (
    <div className="table-view">	
        <div className="table-view__buttons">
            <button className="table-view__button">Add new URL</button>
            <button className="table-view__button">Delete URL</button>
            <button className="table-view__button">View URL</button>
        </div>
        <div className="table-view__header">
            <h1 className="table-view__title">SHORT TABLE VIEW</h1>
        </div>
        <Table columns={columns} data={urls} />
    </div>
  )
}

export default TableView
