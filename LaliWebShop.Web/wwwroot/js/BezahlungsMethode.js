redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51MNzUwD9XscEShKqjJi6ytRsJeb06DbWTLUqlx5BDTt15EPEs2rPvBILoyHNnn0h8evHj4PQQdfdaxoCTQKo5e5r00sVNPp5jO");
    stripe.redirectToCheckout({ sessionId: sessionId });
}