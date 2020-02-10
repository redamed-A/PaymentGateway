import React, { Component } from 'react';

export class PaymentList extends Component {
    displayName = PaymentList.name

    constructor(props) {
        super(props);
        this.state = { paymentList: [], loading: true };

        fetch('http://localhost:3501/api/Payments')
            .then(response => response.json())
            .then(data => {
                this.setState({ paymentList: data, loading: false });
            });
    }

    static renderPaymentListTable(paymentList) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>BankIdTransaction</th>
                        <th>Price</th>
                        <th>CardNumber (C)</th>
                        <th>Cvv (F)</th>
                        <th>ExpiryMonth</th>
                        <th>ExpiryYear</th>
                    </tr>
                </thead>
                <tbody>
                    {paymentList.map((payment, index) =>
                        <tr key={index}>
                            <td>{payment.name}</td>
                            <td>{payment.bankIdTransaction}</td>
                            <td>{payment.amount} {payment.currency}</td>
                            <td>{payment.cardNumber}</td>
                            <td>{payment.cvv}</td>
                            <td>{payment.expiryMonth}</td>
                            <td>{payment.expiryYear}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : PaymentList.renderPaymentListTable(this.state.paymentList);

        return (
            <div>
                <h1>Payments Lists</h1>
                <p>Here we display all the payments.</p>
                {contents}
            </div>
        );
    }
}
