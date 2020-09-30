import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import config from "../config";
import DataTable from "./Tables/DataTable";
import ModalForm from "./Modals/Modal";

export class Merchants extends Component {
    state = {
        items: [],
        countries: [],
        currencies: [],
        currencyMap: new Map(),
        countryMap: new Map(),
        statusMap: new Map(),
        allStatus: [],
        isLoading: true,
    };

    getItems = async () => {
        try {
            const getMerchantsResponse = await fetch(
                config.baseUrl + config.merchants
            );
            if (getMerchantsResponse.ok) {
                let { items } = await getMerchantsResponse.json();
                this.setState({ items, isLoading: false });
            }
        } catch (err) {
            console.log(err);
        }
    };

    getCountries = async () => {
        try {
            const getCountriesResponse = await fetch(
                config.baseUrl + config.countries
            );
            if (getCountriesResponse.ok) {
                let countries = await getCountriesResponse.json();
                let countryMap = new Map();
                countries.reduce((acc, item) => {
                    acc.set(item.id, item);
                    return acc;
                }, countryMap);
                this.setState({ countries, countryMap });
            }
        } catch (err) {
            console.log(err);
        }
    };

    getCurrencies = async () => {
        try {
            const getCurrenciesResponse = await fetch(
                config.baseUrl + config.currencies
            );
            if (getCurrenciesResponse.ok) {
                let currencies = await getCurrenciesResponse.json();
                let currencyMap = new Map();
                currencies.reduce((acc, item) => {
                    acc.set(item.id, item);
                    return acc;
                }, currencyMap);
                this.setState({ currencies, currencyMap });
            }
        } catch (err) {
            console.log(err);
        }
    };

    getAllStatus = async () => {
        try {
            const getallStatusResponse = await fetch(config.baseUrl + config.status);
            if (getallStatusResponse.ok) {
                let allStatus = await getallStatusResponse.json();
                let statusMap = new Map();
                allStatus.reduce((acc, item) => {
                    acc.set(item.id, item);
                    return acc;
                }, statusMap);
                this.setState({ allStatus, statusMap });
            }
        } catch (err) {
            console.log(err);
        }
    };

    addItemToState = (item) => {
        this.setState((prevState) => ({
            items: [...prevState.items, item],
        }));
    };

    updateState = (item) => {
        const itemIndex = this.state.items.findIndex((data) => data.id === item.id);
        const newArray = [
            // destructure all items from beginning to the indexed item
            ...this.state.items.slice(0, itemIndex),
            // add the updated item to the array
            item,
            // add the rest of the items to the array from the index after the replaced item
            ...this.state.items.slice(itemIndex + 1),
        ];
        this.setState({ items: newArray });
    };

    deleteItem = async (merchant) => {
        try {
            const { id } = merchant;
            const deleteMerchantResponse = await fetch(
                config.baseUrl + config.merchants + `/${id}`,
                { method: "DELETE" }
            );
            if (deleteMerchantResponse.ok && deleteMerchantResponse.status === 204) {
                const updatedItems = this.state.items.filter((item) => item.id !== id);
                this.setState({ items: updatedItems });
            }
        } catch (err) {
            console.log(err);
        }
    };

    componentDidMount() {
        this.getItems();
        this.getCountries();
        this.getCurrencies();
        this.getAllStatus();
    }

    render() {
        return (
            <Container className="Merchant-App">
                <Row>
                    <Col>
                        <h1 style={{ margin: "20px 0" }}>Merchants</h1>
                    </Col>
                </Row>
                {this.state.isLoading ? (
                    "loading..."
                ) : (
                        <>
                            <Row>
                                <Col>
                                    <DataTable
                                        countries={this.state.countries}
                                        currencies={this.state.currencies}
                                        allStatus={this.state.allStatus}
                                        countryMap={this.state.countryMap}
                                        currencyMap={this.state.currencyMap}
                                        statusMap={this.state.statusMap}
                                        items={this.state.items}
                                        updateState={this.updateState}
                                        deleteItem={this.deleteItem}
                                    ></DataTable>
                                </Col>
                            </Row>
                            <Row>
                                <ModalForm
                                    countries={this.state.countries}
                                    currencies={this.state.currencies}
                                    allStatus={this.state.allStatus}
                                    buttonLabel="Add Item"
                                    addItemToState={this.addItemToState}
                                ></ModalForm>
                            </Row>
                        </>
                    )}
            </Container>
        );
    }
}
