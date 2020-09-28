import React, { Component } from "react";
import { Table, Button } from "reactstrap";
import ModalForm from "../Modals/Modal";

class DataTable extends Component {
  render() {
    const items = this.props.items.map((item) => {
      let countryName = this.props.countryMap.get(item.countryId)
        ? this.props.countryMap.get(item.countryId).name
        : "";
      let currencyName = this.props.currencyMap.get(item.currencyId)
        ? this.props.currencyMap.get(item.currencyId).name
        : "";
      let statusName = this.props.statusMap.get(item.status)
        ? this.props.statusMap.get(item.status).name
        : "";
      return (
        <tr key={item.id}>
          <td>{item.name}</td>
          <td>{countryName}</td>
          <td>{item.websiteUrl}</td>
          <td>{currencyName}</td>
          <td>{item.discountPercentage}</td>
          <td>{statusName}</td>
          <td>
            <div style={{ width: "120px" }}>
              <ModalForm
                buttonLabel="Edit"
                countries={this.props.countries}
                currencies={this.props.currencies}
                allStatus={this.props.allStatus}
                item={item}
                updateState={this.props.updateState}
              />{" "}
              <Button
                color="danger"
                onClick={() => this.props.deleteItem(item)}
              >
                Del
              </Button>
            </div>
          </td>
        </tr>
      );
    });

    return (
      <Table responsive hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Country</th>
            <th>Website Url</th>
            <th>Currency</th>
            <th>Discount Percentage</th>
            <th>Status</th>
            <th>{""}</th>
          </tr>
        </thead>
        <tbody>{items}</tbody>
      </Table>
    );
  }
}

export default DataTable;
