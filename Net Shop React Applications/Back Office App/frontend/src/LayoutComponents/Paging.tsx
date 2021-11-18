import React from "react";
import { Pagination } from "react-bootstrap";

interface Props{
    currentPage: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
}

export const Paging = ({currentPage, totalPages, hasPrevious, hasNext}:Props) => {
    
    return (
        <Pagination>
            {for (let i = 1; i < totalPages; i++){

            }}
        </Pagination>
    )
}