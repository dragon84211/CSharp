def total(prices)
    amount = 0
    prices.each do |price|
        amount+=price
    end
    amount #returns the final total
end

def refund(prices)
    amount = 0
    prices.each do |price|
        amount-=price
    end
    amount
end

def show_discounts(prices)
    prices.each do |price|
        amount_off = price / 3
        puts format("Your discount: $%.2f", amount_off)
    end
end

prices = [3.99, 25.00, 8.99]
 
puts format("%.2f", total(prices))
puts format("%.2f", refund(prices))
show_discounts(prices)

=begin
#Simplified version of what the each method is doing
def each 
    index = 0 
    while index < self.length 
        yield self[index] #passes the value at the index back to the block
        index += 1 
    end 
end
=end