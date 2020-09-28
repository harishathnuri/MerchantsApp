import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Merchants Application and API</h1>
        <p>
          We want you to create an API(.net core) and APP (React) which can be
          used to create, view, update and delete merchants. At this point do
          not worry about authentication.
        </p>
        <p>
          <strong>Here are a few characteristics of a Merchant</strong>
        </p>
        <ul>
          <li>Unique ID</li>
          <li>Status (Active/Inactive)</li>
          <li>Currency</li>
          <li>Website URL</li>
          <li>Country</li>
          <li>Discount Percentage</li>
        </ul>
        <p>
          <strong>Things to think about:</strong>
        </p>
        <ul>
          <li>
            Think about points of failure and how your endpoint will perform
            under load.
          </li>
          <li>
            Language/frameworks: .Net core is preferred, use docker-compose to
            set up any datastore of your choice
          </li>
          <li>
            Testing: use whatever tools you prefer to test your code
            appropriately
          </li>
          <li>
            Try to implement appropriate separation of concerns & modular code
          </li>
          <li>
            Think hard about the naming of functions and variables. Your code
            must be readable
          </li>
          <li>
            Code style & file structure is up to you, but make sure it is
            consistent and easy to understand
          </li>
        </ul>
      </div>
    );
  }
}
