import React, { Component } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";
import config from "../../config";

const EMPTY_GUID = "00000000-0000-0000-0000-000000000000";

export default class AddEditForm extends Component {
  state = {
    id: EMPTY_GUID,
    name: "",
    countryId: this.props.countries[0].id,
    websiteUrl: "",
    currencyId: this.props.currencies[0].id,
    discountPercentage: 0,
    status: this.props.allStatus[0].id,
  };

  onChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  onChangeIntType = (e) => {
    this.setState({ [e.target.name]: parseInt(e.target.value, 10) });
  };

  submitFormAdd = async (e) => {
    e.preventDefault();
    try {
      const body = JSON.stringify({
        name: this.state.name,
        countryId: this.state.countryId,
        websiteUrl: this.state.websiteUrl,
        currencyId: this.state.currencyId,
        discountPercentage: this.state.discountPercentage,
        status: this.state.status,
      });
      const postMerchantsResponse = await fetch(
        config.baseUrl + config.merchants,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body,
        }
      );
      if (postMerchantsResponse.ok) {
        let merchant = await postMerchantsResponse.json();
        this.props.addItemToState(merchant);
        this.props.toggle();
      }
    } catch (err) {
      console.log(err);
    }
  };

  submitFormEdit = async (e) => {
    e.preventDefault();
    try {
      const body = JSON.stringify({
        name: this.state.name,
        countryId: this.state.countryId,
        websiteUrl: this.state.websiteUrl,
        currencyId: this.state.currencyId,
        discountPercentage: this.state.discountPercentage,
        status: this.state.status,
      });
      const putMerchantsResponse = await fetch(
        config.baseUrl + config.merchants + "/" + this.state.id,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body,
        }
      );
      if (putMerchantsResponse.ok) {
        this.props.updateState(this.state);
        this.props.toggle();
      }
    } catch (err) {
      console.log(err);
    }
  };

  componentDidMount() {
    if (this.props.item) {
      const {
        id,
        name,
        countryId,
        websiteUrl,
        currencyId,
        discountPercentage,
        status,
      } = this.props.item;
      this.setState({
        id,
        name,
        countryId,
        websiteUrl,
        currencyId,
        discountPercentage,
        status,
      });
    }
  }

  render() {
    console.log(this);
    return (
      <Form
        onSubmit={this.props.item ? this.submitFormEdit : this.submitFormAdd}
      >
        <FormGroup>
          <Label for="name">Name</Label>
          <Input
            type="text"
            name="name"
            id="name"
            onChange={this.onChange}
            value={this.state.name === null ? "" : this.state.name}
          />
        </FormGroup>
        <FormGroup>
          <Label for="country">Country</Label>
          <Input
            type="select"
            name="countryId"
            id="countryId"
            onChange={this.onChange}
            value={this.state.countryId}
          >
            {this.props.countries.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label for="websiteUrl">Website URL</Label>
          <Input
            type="text"
            name="websiteUrl"
            id="websiteUrl"
            onChange={this.onChange}
            value={this.state.websiteUrl === null ? "" : this.state.websiteUrl}
          />
        </FormGroup>
        <FormGroup>
          <Label for="currency">Currency</Label>
          <Input
            type="select"
            name="currencyId"
            id="currencyId"
            onChange={this.onChange}
            value={this.state.currencyId}
          >
            {this.props.currencies.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label for="discountPercentage">Discount Percentage</Label>
          <Input
            type="text"
            name="discountPercentage"
            id="discountPercentage"
            onChange={this.onChange}
            value={
              this.state.discountPercentage === null
                ? ""
                : this.state.discountPercentage
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="status">Status</Label>
          <Input
            type="select"
            name="status"
            id="status"
            onChange={this.onChangeIntType}
            value={this.state.status}
          >
            {this.props.allStatus.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <Button>Submit</Button>
      </Form>
    );
  }
}
