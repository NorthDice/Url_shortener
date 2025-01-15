import React from 'react';
import './Table.css';

function Table({ columns, data }) {
  return (
    <div className="table-view__container">
      <table className="table-view__table">
        <thead className="table-view__header">
          <tr>
            {columns.map((column, index) => (
              <th key={index} className="table-view__header-cell">
                {column}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((row, rowIndex) => (
            <tr key={rowIndex} className="table-view__row">
              {columns.map((column, colIndex) => (
                <td key={colIndex} className="table-view__cell">
                  {row[column]}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Table;
