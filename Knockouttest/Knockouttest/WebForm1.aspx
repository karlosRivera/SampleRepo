<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Knockouttest.WebForm1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.11.3/jquery-ui.min.js"></script>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.3.0.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <button id="button" data-bind="click: addRow" type="button">click</button>
    <div id="dash" data-bind="foreach: {data : rows, beforeRemove : ElementFadeOut, afterAdd:ElementFadeIn}">
        <div data-bind="text:$data">
        </div>
    </div>

    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            function TableModel() {
                var self = this;
                self.Counter = 1;
                self.rows = ko.observableArray([]),
                self.addRow = function () {
                    self.rows.push(self.Counter + ' ' + new Date());
                    self.Counter++;
                    setTimeout(function () {
                        self.rows.shift();
                        self.Counter--;
                    }, self.rows().length * 1000);
                },

                self.ElementFadeOut = function (element, index, data) {
                    alert('out');
                    $(element).fadeOut()
                }

                self.ElementFadeIn = function (element, index, data) {
                    alert('in');
                    $(element).fadeIn()
                }

            }
            ko.applyBindings(new TableModel());
        });
    </script>

</body>
</html>
