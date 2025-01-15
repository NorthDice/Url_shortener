import React from 'react'
import './TableView.css'

const TableView = () => {
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
        <table className="table-view__table">
            <thead>
                <tr>
                    <th>
                        Id
                    </th>
                    <th>
                        Original URL
                    </th>
                    <th>
                        Short URL
                    </th>
                </tr>
            </thead>

            <tbody>
                <tr>
                    <td>
                        dsadasdsa
                    </td>
                    <td>
                        dsadasdsa
                    </td>
                    <td>
                        dsadasdsa
                    </td>
                </tr>
            </tbody>

        </table>
    </div>
  )
}

export default TableView
