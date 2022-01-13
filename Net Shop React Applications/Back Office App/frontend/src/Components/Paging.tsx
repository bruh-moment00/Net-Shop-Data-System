import React from "react";
import { Dropdown, PageItem, Pagination } from "react-bootstrap";
import { useSearchParams, useNavigate } from "react-router-dom";

interface Props {
  pageNumber: number;
  totalPages: number;
  hasPrevious: boolean;
  hasNext: boolean;
  pageSize?: number;
}

export const Paging = ({
  pageNumber,
  totalPages,
  hasPrevious,
  hasNext,
  pageSize,
}: Props) => {
  const pageNumbers = [];

  const [searchParams] = useSearchParams();
  const navigate = useNavigate();

  for (let i = 1; i <= totalPages; i++) {
    pageNumbers.push(i);
  }

  const handlePageChange = (number: number) => {
    searchParams.set("pageNumber", number.toString());
    navigate(`?${searchParams.toString()}`);
  };

  return (
    <div>
      <Pagination>
        <PageItem
          disabled={!hasPrevious}
          onClick={(event: React.MouseEvent<HTMLElement>) => {
            handlePageChange(pageNumber - 1);
          }}
        >
          Назад
        </PageItem>
        {pageNumbers.map((number) =>
          number === pageNumber ? (
            <PageItem key={number} active>
              {number}
            </PageItem>
          ) : (
            <PageItem
              key={number}
              onClick={(event: React.MouseEvent<HTMLElement>) => {
                handlePageChange(number);
              }}
            >
              {number}
            </PageItem>
          )
        )}
        <PageItem
          disabled={!hasNext}
          onClick={(event: React.MouseEvent<HTMLElement>) => {
            handlePageChange(pageNumber + 1);
          }}
        >
          Вперед
        </PageItem>
      </Pagination>
      <Dropdown>
        <Dropdown.Toggle>Элементов на странице: {pageSize}</Dropdown.Toggle>
        <Dropdown.Menu>
          <Dropdown.Item
            onClick={(event: React.MouseEvent<HTMLElement>) => {
              searchParams.set("pageSize", "5");
              navigate(`?${searchParams.toString()}`);
            }}
          >
            5
          </Dropdown.Item>
          <Dropdown.Item>10</Dropdown.Item>
          <Dropdown.Item>15</Dropdown.Item>
          <Dropdown.Item>20</Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>
    </div>
  );
};
