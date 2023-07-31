data Color = Red | Green | Yellow

getSecond :: [String] -> String
getSecond a = a !! 1

getPureSecond :: [String] -> [String]
getPureSecond a = [a !! 1]

printSecondElement :: IO ()
printSecondElement = print . getSecond $ ["paco", "juan", "montse"]

printPureSecondElement :: IO ()
printPureSecondElement = print . concat . getPureSecond $ ["paco", "miguel", "alberto", "juan"]

printOnConsole :: IO ()
printOnConsole = print . sum . filter (> 2) . map read . words $ "1 2 3 4 5 6"

printWithFoldl :: IO ()
printWithFoldl = print $ foldl (<>) "Hello " ["J", "o", "n", "!"]

printWithFoldl1 :: IO ()
printWithFoldl1 = print $ foldl1 (<>) ["J", "o", "n", "!"]

foo :: Num a => a -> a
foo a = a + 10

bar :: Num a => a -> a -- This is the same as the function above. Linter doesn't suggest anything in favour of this syntax; kind of counter intuitive.
bar = (+ 10)

printListComprehensionSumResult :: IO ()
printListComprehensionSumResult = print . sum $ [x * 2 | x <- [1, 2, 3, 4], x > 1]

fibGuards :: (Ord t, Num t, Num a) => t -> a
fibGuards x
  | x < 2 = 1
  | otherwise = fibGuards (x - 1) + fibGuards (x - 2)

fibTernary :: (Ord t, Num t, Num a) => t -> a
fibTernary x = if x < 2 then 1 else fibTernary (x - 1) + fibTernary (x - 2)

fibPM :: (Eq t, Num t, Num a) => t -> a
fibPM 1 = 1
fibPM 2 = 2
fibPM x = fibPM (x - 1) + fibPM (x - 2)

getColor :: Color -> String
getColor Red = "It's red"
getColor Green = "It's green"
getColor Yellow = "It's yellow"

class Walkable a where
  (===) :: a -> a -> Bool

instance Walkable Color where
  (===) :: Color -> Color -> Bool
  Green === Green = True
  _ === _ = False

shouldICross :: Color -> Bool
shouldICross c = c === Green

monadicMapAndFilter :: [Integer] -> [Integer]
monadicMapAndFilter x = x >>= \a -> [a + 1] >>= \b -> ([b | b /= 3])

main :: IO ()
main = print . sum . monadicMapAndFilter $ [1, 2, 3]