<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="we.aspx.cs" Inherits="Knockouttest.we" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #dash
        {
            max-height: 128px;
            overflow: hidden;
        }
        #dash div
        {
            border: 1px solid #de2345;
            padding: 4px;
            margin: 2px;
            line-height: 20px;
            box-sizing: border-box;
        }
        #dash div:before
        {
            content: '--> ';
        }
    </style>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.3.0.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <p>
        message is: <span data-bind="text: userName"></span>
    </p>
    <p>
        Login name:
        <input data-bind="textInput: userName" /></p>
    </form>
    <script type="text/javascript">
        var viewModel = {
            userName: ko.observable("")
        };

        ko.applyBindings(viewModel);
    </script>

</body>
</html>
