import React, { Component } from "react";
import { Button, Modal, ModalHeader, ModalBody } from "reactstrap";
import AddEditForm from "../Forms/AddEditForm";

export default class ModalForm extends Component {
  state = {
    modal: false,
  };

  toggle = () => {
    this.setState((prevState) => ({
      modal: !prevState.modal,
    }));
  };

  render() {
    const closeBtn = (
      <button className="close" onClick={this.toggle}>
        &times;
      </button>
    );
    const label = this.props.buttonLabel;
    let button = "";
    let title = "";

    if (label === "Edit") {
      button = (
        <Button
          color="warning"
          onClick={this.toggle}
          style={{ float: "left", marginRight: "10px" }}
        >
          {label}
        </Button>
      );
      title = "Edit Merchant";
    } else {
      button = (
        <Button
          color="success"
          onClick={this.toggle}
          style={{ float: "left", marginRight: "10px" }}
        >
          {label}
        </Button>
      );
      title = "Add New Item";
    }
    return (
      <>
        {button}
        <Modal
          isOpen={this.state.modal}
          toggle={this.toggle}
          className={this.props.className}
        >
          <ModalHeader toggle={this.toggle} close={closeBtn}>
            {title}
          </ModalHeader>
          <ModalBody>
            <AddEditForm
              addItemToState={this.props.addItemToState}
              updateState={this.props.updateState}
              toggle={this.toggle}
              item={this.props.item}
              countries={this.props.countries}
              currencies={this.props.currencies}
              allStatus={this.props.allStatus}
            />
          </ModalBody>
        </Modal>
      </>
    );
  }
}
