import React, { Component } from 'react';
export class AddPayment extends Component {
    constructor(props) {
        super(props);
        this.state = { author: '', text: '' };
        this.state = {
            CardNumber: '',
            Cvv: '',
            ExpiryMonth: '',
            ExpiryYear: '',
            Name: '',
            Amount: '',
            Currency: '',
            MerchantId: ''
        };
        this.handleCardNumberChange = this.handleCardNumberChange.bind(this);
        this.handleCvvChange = this.handleCvvChange.bind(this);
        this.handleExpiryMonthChange = this.handleExpiryMonthChange.bind(this);
        this.handleExpiryYearChange = this.handleExpiryYearChange.bind(this);
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleAmountChange = this.handleAmountChange.bind(this);
        this.handleCurrencyChange = this.handleCurrencyChange.bind(this);
        this.handleMerchantIdChange = this.handleMerchantIdChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
  
    handleCardNumberChange(e) {
        this.setState({ CardNumber: e.target.value });
    }
    handleCvvChange(e) {
        this.setState({ Cvv: e.target.value });
    }
    handleExpiryMonthChange(e) {
        this.setState({ ExpiryMonth: e.target.value });
    }
    handleExpiryYearChange(e) {
        this.setState({ ExpiryYear: e.target.value });
    }
    handleNameChange(e) {
        this.setState({ Name: e.target.value });
    }
    handleAmountChange(e) {
        this.setState({ Amount: e.target.value });
    }
    handleCurrencyChange(e) {
        this.setState({ Currency: e.target.value });
    }
    handleMerchantIdChange(e) {
        this.setState({ MerchantId: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        const url = "http://localhost:3501/api/Payments";
            const data = {
                CardNumber: this.state.CardNumber,
                Cvv: this.state.Cvv,
                ExpiryMonth: this.state.ExpiryMonth,
                ExpiryYear: this.state.ExpiryYear,
                Name: this.state.Name,
                Amount: this.state.Amount,
                Currency: this.state.Currency,
                MerchantId: this.state.MerchantId
            }
    
        fetch(url, {
                method: 'POST', 
            body: data,
                headers: { 'Content- Type': 'application/json' }
            })
            .then(res => res.json())
            .catch(error => console.error('Error: ', error))
    .then(response => console.log('Success: ', response)); 
    }
    render() {

        return (
           
            <form className="PaymentForm" onSubmit={this.handleSubmit}>
            <div>
            <h1>Add Payment</h1>
            <p>Here we add payments.</p>
        
            </div>
                <input
                    type="text"
                    placeholder="CardNumber"
                    value={this.state.CardNumber}
                    onChange={this.handleCardNumberChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="Cvv"
                    value={this.state.Cvv}
                    onChange={this.handleCvvChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="ExpiryMonth"
                    value={this.state.ExpiryMonth}
                    onChange={this.handleExpiryMonthChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="ExpiryYear"
                    value={this.state.ExpiryYear}
                    onChange={this.handleExpiryYearChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="Name"
                    value={this.state.Name}
                    name="name"
                    onChange={this.handleNameChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="Amount"
                    value={this.state.Amount}
                    onChange={this.handleAmountChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="Currency"
                    value={this.state.Currency}
                    onChange={this.handleCurrencyChange}
                />
                <br /><br />
                <input
                    type="text"
                    placeholder="MerchantId"
                    value={this.state.MerchantId}
                    onChange={this.handleMerchantIdChange}
                />
                <br /><br />
                <input type="submit" value="Save Payment" />
            </form>
        );
    }
}