<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Knockouttest.Products" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table 
    {
        border: solid 1px #e8eef4;
        border-collapse: collapse;
    }
    
    table th
    {
        padding: 6px 5px;
        background-color: #e8eef4; 
        border: solid 1px #e8eef4;   
    }

    table td 
    {
        padding:0 3px 0 3px;
        margin: 0px;
        height: 20px;
        border: solid 1px #e8eef4;
    }

    td.number
    {
        width: 100px;
        text-align:right;
    }
    
    td.editable
    {
        background-color:#fff;
    }
    
    td.editable input
    {
        font-family: Verdana, Helvetica, Sans-Serif;
        text-align: right;
        width: 100%;
        height: 100%;
        border: 0;
    }
    
    td.editing
    {
        border: 2px solid Blue;
    }
    </style>
        <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.3.0.js"></script>
        <script type="text/javascript" src="https://github.com/jquery/jquery-tmpl/raw/master/jquery.tmpl.js"></script>

    
</head>
<body>
    <form id="form1" runat="server">

<table id="table1" cellspacing="0" cellpadding="0" border="0">
    <tr>
        <th style="width:150px">Product</th>
        <th>Price ($)</th>
        <th>Quantity</th>
        <th>Amount ($)</th>
    </tr>

    <tbody data-bind='template: {name: "orderTemplate", foreach: lines}'></tbody>
</table>
<script type="text/html" id="orderTemplate">
    <tr>
        <td>
            <select data-bind='options: products, optionsText: "name", value: "id", optionsCaption:"--Select--", value: product'></select>
        </td>
        <td data-bind='with: product'>
            <span data-bind='text: formatCurrency(price)'></span>
        </td>
        // removed the data-bind here because it was getting the quantity assigned to the product
        // not from the input text box
        <td>
            <input data-bind='value: quantity, valueUpdate: "afterkeydown"' />
        </td>
        <td><span data-bind='text: subtotal()'></span></td>
    </tr>
</script>

<script type="text/javascript">
    var _products = [
    {
        "name": "1948 Porsche 356-A Roadster",
        "price": 53.9,
        "quantity": 1
    },
    {
        "name": "1948 Porsche Type 356 Roadster",
        "price": 62.16,
        "quantity": 2
    },
    {
        "name": "1949 Jaguar XK 120",
        "price": 47.25,
        "quantity": 1
    },
    {
        "name": "1952 Alpine Renault 1300",
        "price": 98.58,
        "quantity": 1
    },
    {
        "name": "1952 Citroen-15CV",
        "price": 72.82,
        "quantity": 1
    },
    {
        "name": "1956 Porsche 356A Coupe",
        "price": 98.3,
        "quantity": 1
    },
    {
        "name": "1957 Corvette Convertible",
        "price": 69.93,
        "quantity": 1
    }];

    function formatCurrency(value) {
        return "$" + value.toFixed(2);
    }

    var CartLine = function () {
        var self = this;
        self.products = ko.observableArray(_products);
        self.product = ko.observable(null); // set to null as it holds your selected product from the select element

        self.price = ko.observable(1); //do not this
        self.quantity = ko.observable(1);

        self.subtotal = ko.computed(function () {
            if (!self.product()) // on load self.product() will be null, return to avoid error
                return;
            // you get the select products price and multiple it by the quantity from the textbox
            return formatCurrency(self.product().price * self.quantity());
        });

    };

    var Cart = function () {
        // Stores an array of lines, and from these, can work out the grandTotal
        var self = this;
        self.lines = ko.observableArray([new CartLine()]); // Put one line in by default
    };

    ko.applyBindings(new Cart());
</script>

    </form>
</body>
</html>
