Cart = {
    _properties: {
        addToCartLink: ""
    },

    init: function (properties) {
        $.extend(Cart._properties, properties);
        $(".CallAddToCart").click(Cart.addToCart);
    },

    /**
     * @param {Event} event The date
     */
    addToCart: function (event) {
        var button = $(this);
        event.preventDefault();
        var id = button.data("id");

        $.get(Cart._properties.addToCartLink + "/" + id)
            .done(alert("Ok"))
            .fault(alert("Not Ok"));
    }
};