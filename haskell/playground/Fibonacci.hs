getNthFibo :: Int -> Int
getNthFibo 1 = 0
getNthFibo 2 = 1
getNthFibo n = getNthFibo (n - 1) + getNthFibo (n - 2)

getFiboSeries :: Int -> [Int]
getFiboSeries 0 = []
getFiboSeries n = getFiboSeries (n - 1) ++ [getNthFibo n]

main :: IO ()
main = print $ getFiboSeries 10