import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { PaymentList } from './components/PaymentList';
import { AddPayment } from './components/AddPayment';
import { Counter } from './components/Counter';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
            <Route path='/paymentlist' component={PaymentList} />
            <Route path='/addPayment' component={AddPayment} />
      </Layout>
    );
  }
}
